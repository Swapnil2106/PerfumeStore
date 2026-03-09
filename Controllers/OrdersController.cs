using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.Models.Enums;
using PerfumeStore.Services.Interfaces;
using System.Security.Claims;

namespace PerfumeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        private int GetUserId()                                                                     //Get the UserId from the Token
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserOrders()
        {
            var userId = GetUserId();
            var allOrders = await orderService.GetUserOrders(userId);

            return Ok(allOrders);
        }

        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout()
        {
            var userId = GetUserId();
            var result = await orderService.Checkout(userId);

            return Ok(result);
        }

        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var result = await orderService.UpdateOrderStatus(orderId, status);

            return Ok(result);
        }
    }
}
