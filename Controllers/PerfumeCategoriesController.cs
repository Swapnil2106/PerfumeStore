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
        public async Task<IActionResult> AddCategory(AddPerfumeCategoryDTO dto)
        {
            var createdCategory = await perfumeCategoryService.AddPerfumeCategory(dto);

            return Ok(createdCategory);
        }
    }
}
