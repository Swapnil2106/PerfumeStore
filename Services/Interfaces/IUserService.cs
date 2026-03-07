using PerfumeStore.DTOs.Auth;
using PerfumeStore.DTOs.User;

namespace PerfumeStore.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> RegisterUser(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
        Task<UserDTO> UpdateUser(int id, UpdateUserDTO dto);
        Task DeleteUser(int id);
    }
}
