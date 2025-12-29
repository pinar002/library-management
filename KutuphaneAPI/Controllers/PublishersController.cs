using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneAPI.Data;
using KutuphaneAPI.Models;

namespace KutuphaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly AppDbContext _db;

        public PublishersController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
        {
            return await _db.Publishers.ToListAsync();
        }
        
        [HttpPost]
        public async Task<ActionResult<Publisher>> Create(Publisher publisher)
        {
             _db.Publishers.Add(publisher);
             await _db.SaveChangesAsync();
             return CreatedAtAction(nameof(GetPublishers), new { id = publisher.Id }, publisher);
        }
    }
}
