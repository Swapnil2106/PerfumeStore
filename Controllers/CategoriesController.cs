using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.DTOs;
using PerfumeStore.Services;

namespace PerfumeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerfumeCategories()
        {
            var categories = await categoryService.GetAllPerfumeCategories();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerfumeCategory(AddCategoryDTO dto)
        {
            var createdCategory = await categoryService.AddPerfumeCategory(dto);

            return Ok(createdCategory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfumeCategoryById(int id)
        {
            var perfumeCategory = await categoryService.GetPerfumeCategoryById(id);

            return Ok(perfumeCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerfumeCategory(int id, UpdateCategoryDTO dto)
        {
            var updatedPerfumeCategory = await categoryService.UpdatePerfumeCategory(id, dto);

            return Ok(updatedPerfumeCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfumeCategory(int id)
        {
            await categoryService.DeletePerfumeCategory(id);
            return NoContent(); // 204
        }

    }
}
