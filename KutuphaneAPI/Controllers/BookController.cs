/*
 * Kitaplarla ilgili tüm işlemleri yapan controller
 * API endpoint'leri burada tanımlanır
 * 
 * Yapabileceklerimiz:
 * - Kitapları listeleme işlemi
 * - Yeni kitap ekleme
 * - Kitap güncelleme
 * - Kitap silme
 * - Kitap arama
 * - Ödünç alma/iade işlemleri
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneAPI.Data;
using KutuphaneAPI.Models;
using KutuphaneAPI.Models.DTOs;

namespace KutuphaneAPI.Controllers
{
    [Route("api/[controller]")]  // URL: api/books
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Veritabanı bağlantısı
        private readonly AppDbContext _db;

        // Constructor - veritabanını kullanabilmek için
        public BooksController(AppDbContext db) 
        { 
            _db = db; 
        }

        // TÜM KİTAPLARI GETİR
        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var kitaplar = await _db.Books
                .Include(b => b.Authors)
                .Include(b => b.Publisher)
                .Include(b => b.Categories)
                .ToListAsync();
            return kitaplar;
        }

        // TEK BİR KİTABI GETİR (ID'ye göre)
        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var kitap = await _db.Books
                .Include(b => b.Authors)
                .Include(b => b.Publisher)
                .Include(b => b.Categories)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (kitap == null) 
                return NotFound();
            
            return kitap;
        }

        // YENİ KİTAP EKLE
        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> Create(BookCreateDto bookDto)
        {
            // Publisher check
            var publisher = await _db.Publishers.FindAsync(bookDto.PublisherId);
            if (publisher == null)
                return BadRequest("Invalid Publisher ID");

            // Authors check
            var authors = new List<Author>();
            foreach(var authId in bookDto.AuthorIds)
            {
                var author = await _db.Authors.FindAsync(authId);
                if(author != null) authors.Add(author);
            }

            // Categories check
            var categories = new List<Category>();
            foreach(var catId in bookDto.CategoryIds)
            {
                var category = await _db.Categories.FindAsync(catId);
                if(category != null) categories.Add(category);
            }

            var book = new Book
            {
                Title = bookDto.Title,
                ISBN = bookDto.ISBN,
                PublishYear = bookDto.PublishYear,
                StockCount = bookDto.StockCount,
                Publisher = publisher,
                Authors = authors,
                Categories = categories
            };

            _db.Books.Add(book);
            
            await _db.SaveChangesAsync();
        
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        // KİTAP GÜNCELLE
        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            // URL'deki ID ile gönderilen kitabın ID'si eşleşmeli
            if (id != book.Id) 
                return BadRequest();

            // Kitabı güncellemeye hazırla
            _db.Entry(book).State = EntityState.Modified;

            try 
            {
                await _db.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitapVarMi(id)) 
                    return NotFound();
                else 
                    throw;  
            }

            // 204 No Content dön (başarılı ama body yok)
            return NoContent();
        }

        // KİTAP SİL
        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kitap = await _db.Books.FindAsync(id);
            
            // Kitap yoksa 404
            if (kitap == null) 
                return NotFound();
            
            _db.Books.Remove(kitap);
            
            await _db.SaveChangesAsync();
            
            return NoContent();
        }

        // KİTAP ARAMA (başlık, yazar, ISBN'de ara)
        // GET: api/books/search?query=orwell
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Book>>> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await _db.Books
                    .Include(b => b.Authors)
                    .Include(b => b.Publisher)
                    .Include(b => b.Categories)
                    .ToListAsync();

            query = query.ToLower();

            var sonuclar = await _db.Books
                .Include(b => b.Authors)
                .Include(b => b.Publisher)
                .Include(b => b.Categories)
                .Where(b => b.Title.ToLower().Contains(query)
                         || b.Authors.Any(a => a.Name.ToLower().Contains(query))
                         || b.ISBN.ToLower().Contains(query))
                .ToListAsync();

            return sonuclar;
        }

        // ÖDÜNÇ ALMA 
        // PUT: api/books/5/borrow
        [HttpPut("{id}/borrow")]
        public async Task<IActionResult> Borrow(int id)
        {
            var kitap = await _db.Books.FindAsync(id);
            
            if (kitap == null) 
                return NotFound();
            
            if (kitap.StockCount <= 0) 
                return BadRequest(new { message = "StockEmpty" });
            
            kitap.StockCount--;
            
            await _db.SaveChangesAsync();
            
            return NoContent();
        }

        // İADE ETME 
        // PUT: api/books/5/return
        [HttpPut("{id}/return")]
        public async Task<IActionResult> Return(int id)
        {
            var kitap = await _db.Books.FindAsync(id);
            
            if (kitap == null) 
                return NotFound();
            
            kitap.StockCount++;

            await _db.SaveChangesAsync();
            
            return NoContent();
        }

        private bool KitapVarMi(int id) 
        {
            return _db.Books.Any(e => e.Id == id);
        }
    }
}