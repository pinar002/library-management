using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneAPI.Data;
using KutuphaneAPI.Models;

namespace KutuphaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _db.Categories.ToListAsync();
        }
        
        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category category)
        {
             _db.Categories.Add(category);
             await _db.SaveChangesAsync();
             return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, category);
        }
    }
}
