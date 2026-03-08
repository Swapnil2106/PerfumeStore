using Microsoft.EntityFrameworkCore;
using PerfumeStore.Data;
using PerfumeStore.Services.Interfaces;

namespace PerfumeStore.Services
{
    public class OrderService: IOrderService
    {
        private readonly ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<object> GetUserOrders(int userId)
        {
            var orders = await dbContext.Orders.AsNoTracking().ToListAsync();

            return orders;
        }
    }
}
