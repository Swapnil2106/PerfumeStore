using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.DTOs;
using PerfumeStore.Services;

namespace PerfumeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumeTypesController : ControllerBase
    {
        private readonly IPerfumeTypeService perfumeTypeService;

        public PerfumeTypesController(IPerfumeTypeService _perfumeTypeService)
        {
            perfumeTypeService = _perfumeTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerfumeTypes()
        {
            var types = await perfumeTypeService.GetAllPerfumeTypes();

            return Ok(types);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerfumeType(AddPerfumeTypeDTO dto)
        {
            var createdType = await perfumeTypeService.AddPerfumeType(dto);

            return Ok(createdType);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfumeTypeById(int id)
        {
            var perfumeType = await perfumeTypeService.GetPerfumeTypeById(id);

            return Ok(perfumeType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerfumeType(int id, UpdatePerfumeTypeDTO dto)
        {
            var updatedPerfumeType = await perfumeTypeService.UpdatePerfumeType(id, dto);

            return Ok(updatedPerfumeType);
        }
    }
}
