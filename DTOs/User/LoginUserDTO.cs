using System.ComponentModel.DataAnnotations;

namespace PerfumeStore.DTOs.Auth
{
    public class LoginUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
