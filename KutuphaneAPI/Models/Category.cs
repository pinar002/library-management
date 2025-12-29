using System.Text.Json.Serialization;

namespace KutuphaneAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        
        [JsonIgnore] // Prevent cycles
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
