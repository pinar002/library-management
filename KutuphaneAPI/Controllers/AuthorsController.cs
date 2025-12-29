using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneAPI.Data;
using KutuphaneAPI.Models;

namespace KutuphaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AuthorsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _db.Authors.ToListAsync();
        }
        
        // Quick add for testing
        [HttpPost]
        public async Task<ActionResult<Author>> Create(Author author)
        {
             _db.Authors.Add(author);
             await _db.SaveChangesAsync();
             return CreatedAtAction(nameof(GetAuthors), new { id = author.Id }, author);
        }
    }
}
