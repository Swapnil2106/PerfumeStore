using PerfumeStore.DTOs;
using PerfumeStore.Models;

namespace PerfumeStore.Services
{
    public interface IPerfumeCategoryService
    {
        Task<IEnumerable<PerfumeCategoryDTO>> GetAllPerfumeCategories();
        Task<PerfumeCategoryDTO> AddPerfumeCategory(AddPerfumeCategoryDTO dto);
        Task<PerfumeCategoryDTO> GetPerfumeCategoryById(int Id);
        Task<PerfumeCategoryDTO> UpdatePerfumeCategory(int Id, UpdatePerfumeCategoryDTO dto);
        Task DeletePerfumeCategory(int Id);
    }
}
