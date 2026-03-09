using PerfumeStore.Models;

namespace PerfumeStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetUserOrders(int userId);
        Task<string> Checkout(int userId);
    }
}
