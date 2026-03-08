namespace PerfumeStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<object> GetUserOrders(int userId);
    }
}
