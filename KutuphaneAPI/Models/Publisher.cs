using System.Text.Json.Serialization;

namespace KutuphaneAPI.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";

        [JsonIgnore]
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
