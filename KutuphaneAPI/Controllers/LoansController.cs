using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneAPI.Data;
using KutuphaneAPI.Models;

namespace KutuphaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _db;

        public LoansController(AppDbContext db)
        {
            _db = db;
        }

        // List active loans or all loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
        {
            return await _db.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .OrderByDescending(l => l.LoanDate)
                .ToListAsync();
        }

        // Borrow a book
        [HttpPost]
        public async Task<ActionResult<Loan>> CreateLoan(Loan loan)
        {
            // Basic validation
            var book = await _db.Books.FindAsync(loan.BookId);
            if (book == null || book.StockCount <= 0)
                return BadRequest("Book not available");

            var member = await _db.Members.FindAsync(loan.MemberId);
            if (member == null)
                return BadRequest("Invalid Member");

            loan.LoanDate = DateTime.Now;
            loan.ReturnDate = null; // Ensure it's null on creation

            // Decrease stock
            book.StockCount--;
            
            _db.Loans.Add(loan);
            await _db.SaveChangesAsync();

            return Ok(loan);
        }

        // Return a book
        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var loan = await _db.Loans
                .Include(l => l.Book)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (loan == null) return NotFound();
            if (loan.ReturnDate != null) return BadRequest("Already returned");

            loan.ReturnDate = DateTime.Now;

            // Increase stock
            if(loan.Book != null)
            {
                loan.Book.StockCount++;
            }

            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
