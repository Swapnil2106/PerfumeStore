using PerfumeStore.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PerfumeStore.DTOs.Auth
{
    public class RegisterUserDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? PhoneNumber { get; set; }
        public UserRole Role { get; set; }
    }
}
