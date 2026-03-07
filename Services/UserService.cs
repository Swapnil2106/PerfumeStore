using PerfumeStore.Data;
using PerfumeStore.DTOs.Auth;
using PerfumeStore.Models;
using PerfumeStore.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PerfumeStore.Services
{
    public class UserService: IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<UserDTO> RegisterUser(RegisterUserDTO dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Role = dto.Role,
                PasswordHash = HashPassword(dto.Password)
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            };
        }

        public string HashPassword(string password)
        {
            var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
