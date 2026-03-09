using PerfumeStore.Models;
using PerfumeStore.Models.Enums;

namespace PerfumeStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetUserOrders(int userId);
        Task<string> Checkout(int userId);
        Task<string> UpdateOrderStatus(int orderId, OrderStatus status);
    }
}
