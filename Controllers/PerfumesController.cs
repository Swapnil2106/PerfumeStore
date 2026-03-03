using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.Services;

namespace PerfumeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumesController : ControllerBase
    {
        private readonly IPerfumeService perfumeService;

        public PerfumesController(IPerfumeService _perfumeService)
        {
            perfumeService = _perfumeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerfumes()
        {
            var perfumes = await perfumeService.GetAllPerfumes();

            return Ok(perfumes);
        }
    }
}
