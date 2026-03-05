using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.DTOs;
using PerfumeStore.Services;

namespace PerfumeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumeCategoriesController : ControllerBase
    {
        private readonly IPerfumeCategoryService perfumeCategoryService;

        public PerfumeCategoriesController(IPerfumeCategoryService _perfumeCategoryService)
        {
            perfumeCategoryService = _perfumeCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerfumeCategories()
        {
            var categories = await perfumeCategoryService.GetAllPerfumeCategories();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerfumeCategory(AddPerfumeCategoryDTO dto)
        {
            var createdCategory = await perfumeCategoryService.AddPerfumeCategory(dto);

            return Ok(createdCategory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfumeCategoryById(int id)
        {
            var perfumeCategory = await perfumeCategoryService.GetPerfumeCategoryById(id);

            return Ok(perfumeCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerfumeCategory(int id, UpdatePerfumeCategoryDTO dto)
        {
            var updatedPerfumeCategory = await perfumeCategoryService.UpdatePerfumeCategory(id, dto);

            return Ok(updatedPerfumeCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfumeCategory(int id)
        {
            await perfumeCategoryService.DeletePerfumeCategory(id);
            return NoContent(); // 204
        }

    }
}
