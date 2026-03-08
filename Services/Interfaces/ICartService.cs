using PerfumeStore.DTOs.Cart;

namespace PerfumeStore.Services.Interfaces
{
    public interface ICartService
    {
        Task<string> AddToCart(int userId, AddToCartDTO dto);
        Task<object> GetCart(int userId);
        Task<string> RemoveFromCart(int cartItemId);
    }
}
