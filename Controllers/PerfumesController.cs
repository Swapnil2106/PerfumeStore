using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.DTOs.Perfume;
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

        [HttpPost]
        public async Task<IActionResult> CreatePerfume(AddPerfumeDTO dto)
        {
            var addedPerfume = await perfumeService.AddPerfume(dto);

            return Ok(addedPerfume);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfumeById(int id)
        {
            var perfume = await perfumeService.GetPerfumeById(id);

            return Ok(perfume);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerfume(int id, UpdatePerfumeDTO dto)
        {
            var updatedPerfume = await perfumeService.UpdatePerfume(id, dto);

            return Ok(updatedPerfume);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfume(int id)
        {
            await perfumeService.DeletePerfume(id);
            return NoContent(); // 204
        }
    }
}
