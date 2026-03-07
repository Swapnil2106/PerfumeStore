using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.DTOs.Type;
using PerfumeStore.Services;

namespace PerfumeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeService typeService;

        public TypesController(ITypeService _typeService)
        {
            typeService = _typeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerfumeTypes()
        {
            var types = await typeService.GetAllPerfumeTypes();

            return Ok(types);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerfumeType(AddTypeDTO dto)
        {
            var createdType = await typeService.AddPerfumeType(dto);

            return Ok(createdType);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfumeTypeById(int id)
        {
            var perfumeType = await typeService.GetPerfumeTypeById(id);

            return Ok(perfumeType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerfumeType(int id, UpdateTypeDTO dto)
        {
            var updatedPerfumeType = await typeService.UpdatePerfumeType(id, dto);

            return Ok(updatedPerfumeType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfumeType(int id)
        {
            await typeService.DeletePerfumeType(id);
            return NoContent(); // 204
        }
    }
}
