using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.Services.Interfaces;
using System.Security.Claims;

namespace PerfumeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
