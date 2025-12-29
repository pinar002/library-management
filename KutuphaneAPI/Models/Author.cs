using System.Text.Json.Serialization;

namespace KutuphaneAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Bio { get; set; } = "";

        [JsonIgnore]
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
