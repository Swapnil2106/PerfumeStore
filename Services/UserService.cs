using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PerfumeStore.Data;
using PerfumeStore.DTOs.Auth;
using PerfumeStore.DTOs.User;
using PerfumeStore.Models;
using PerfumeStore.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PerfumeStore.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfiguration configuration;

        public UserService(ApplicationDbContext _dbContext, IConfiguration _configuration)
        {
            dbContext = _dbContext;
            configuration = _configuration;
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

        private string HashPassword(string password)
        {
            var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || user.PasswordHash != HashPassword(dto.Password))
            {
                throw new Exception("Invalid email or password");
            }

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = configuration.GetSection("Jwt");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"])
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(jwtSettings["DurationInMinutes"])
                ),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserDTO> UpdateUser(int id, UpdateUserDTO dto)
        {
            var userEntity = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            userEntity.FirstName = dto.FirstName;
            userEntity.LastName = dto.LastName;
            userEntity.Email = dto.Email;
            userEntity.PhoneNumber = dto.PhoneNumber;

            await dbContext.SaveChangesAsync();

            var updatedUser = await dbContext.Users.Select(u => new UserDTO
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber
            }).FirstOrDefaultAsync();

            return updatedUser;
        }

        public async Task DeleteUser (int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(c => c.Id == id);

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
