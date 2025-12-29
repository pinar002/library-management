using System.ComponentModel.DataAnnotations;

namespace KutuphaneAPI.Models.DTOs
{
    public class BookCreateDto
    {
        [Required]
        public string Title { get; set; } = "";

        public string ISBN { get; set; } = "";

        public int PublishYear { get; set; }

        public int StockCount { get; set; }

        public int PublisherId { get; set; }

        public List<int> AuthorIds { get; set; } = new List<int>();

        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
