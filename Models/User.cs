using PerfumeStore.Models.Enums;

namespace PerfumeStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; } = UserRole.Customer;                 //defaulted to  customer
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
