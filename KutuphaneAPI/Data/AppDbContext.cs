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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
