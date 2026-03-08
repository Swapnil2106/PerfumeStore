using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.DTOs.Cart;
using PerfumeStore.Services.Interfaces;

namespace PerfumeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartsController(ICartService _cartService)
        {
            cartService = _cartService;
        }

        [HttpPost("Add to Cart")]
        public async Task<IActionResult> AddToCart(int userId, AddToCartDTO dto)
        {
            var message = await cartService.AddToCart(userId, dto);

            return Ok(message);
        }
    }
}
