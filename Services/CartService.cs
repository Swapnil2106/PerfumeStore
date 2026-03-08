using Microsoft.EntityFrameworkCore;
using PerfumeStore.Data;
using PerfumeStore.DTOs.Cart;
using PerfumeStore.Models;
using PerfumeStore.Services.Interfaces;

namespace PerfumeStore.Services
{
    public class CartService: ICartService
    {
        private readonly ApplicationDbContext dbContext;

        public CartService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<string> AddToCart(int userId, AddToCartDTO dto)
        {
            var cart = await dbContext.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);        //Get the existing Cart for an User

            if(cart == null)
            {
                cart = new Cart
                {
                    UserId = userId
                };

                dbContext.Carts.Add(cart);
                await dbContext.SaveChangesAsync();
            }

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.PerfumeId == dto.PerfumeId);                  //Get the existing CartItems for a cart

            if(existingItem != null)
            {
                existingItem.Quantity += dto.Quantity;
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cart.Id,
                    PerfumeId = dto.PerfumeId,
                    Quantity = dto.Quantity
                };

                dbContext.CartItems.Add(cartItem);
            }

            await dbContext.SaveChangesAsync();

            return "Item added to cart";
        }

        public async Task<object> GetCart(int userId)
        {
            var cart = await dbContext.Carts.AsNoTracking().Include(c => c.CartItems).ThenInclude(ci => ci.Perfume).FirstOrDefaultAsync(c => c.UserId == userId);

            if(cart == null)
            {
                return "Cart is Empty";
            }

            return cart;
        }
    }
}
