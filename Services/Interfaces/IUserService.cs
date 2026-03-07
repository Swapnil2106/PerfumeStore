using PerfumeStore.DTOs.Auth;

namespace PerfumeStore.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> RegisterUser(RegisterUserDTO dto);
    }
}
