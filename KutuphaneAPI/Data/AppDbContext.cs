// veritabanı bağlantısı
// entity framework kullanarak sqlite veritabanına bağlanmak

using Microsoft.EntityFrameworkCore;
using KutuphaneAPI.Models;

namespace KutuphaneAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
