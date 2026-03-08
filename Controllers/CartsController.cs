using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.DTOs.Cart;
using PerfumeStore.Services.Interfaces;
using System.Security.Claims;

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

        private int GetUserId()                                                                     //Get the UserId from the Token
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        [HttpPost("Add to Cart")]
        public async Task<IActionResult> AddToCart(AddToCartDTO dto)
        {
            var userId = GetUserId();
            var message = await cartService.AddToCart(userId, dto);

            return Ok(message);
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var userId = GetUserId();
            var result = await cartService.GetCart(userId);

            return Ok(result);
        }
    }
}
