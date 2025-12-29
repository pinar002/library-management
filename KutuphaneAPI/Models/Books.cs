// Veritabanındaki kitap tablosu

namespace KutuphaneAPI.Models
{
    public class Book
    {
        public int Id { get; set; }            

        public string Title { get; set; } = "";

        // Relationships
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();

        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public string ISBN { get; set; } = "";

        public int PublishYear { get; set; }

        public int StockCount { get; set; }
    }
}