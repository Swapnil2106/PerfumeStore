using PerfumeStore.DTOs;

namespace PerfumeStore.Services
{
    public interface IPerfumeCategoryService
    {
        Task<IEnumerable<PerfumeCategoryDTO>> GetAllPerfumeCategories();

        Task<PerfumeCategoryDTO> CreatePerfumeCategory(CreatePerfumeCategoryDTO dto);
    }
}
