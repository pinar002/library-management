
namespace KutuphaneAPI.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // Navigation property for loans history
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
