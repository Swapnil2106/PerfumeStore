using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PerfumeStore.Data;
using PerfumeStore.Models;
using PerfumeStore.Models.Enums;
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

        public async Task<List<Order>> GetUserOrders(int userId)
        {
            var orders = await dbContext.Orders.Where(o => o.UserId == userId).AsNoTracking().Include(o => o.OrderItems).ThenInclude(oi => oi.Perfume).ToListAsync();

            return orders;
        }

        public async Task<string> Checkout(int userId)
        {
            var cart = await dbContext.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Perfume).FirstOrDefaultAsync(c => c.UserId == userId);

            if(cart == null || !cart.CartItems.Any())
            {
                throw new Exception("Cart is Empty");
            }

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                TotalAmount = 0
            };

            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            foreach(var item in cart.CartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    PerfumeId = item.PerfumeId,
                    Quantity = item.Quantity,
                    Price = item.Perfume.Price
                };

                dbContext.OrderItems.Add(orderItem);

                order.TotalAmount += item.Perfume.Price * item.Quantity;
            }

            await dbContext.SaveChangesAsync();

            dbContext.CartItems.RemoveRange(cart.CartItems);

            await dbContext.SaveChangesAsync();

            return "Order Placed Successfully";
        }

        public async Task<string> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var order = await dbContext.Orders.FindAsync(orderId);

            if(order == null)
            {
                throw new Exception("Order not Found");
            }

            order.Status = status;

            await dbContext.SaveChangesAsync();

            return "Order status updated Successfully";
        }
    }
}
