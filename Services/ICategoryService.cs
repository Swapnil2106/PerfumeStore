using PerfumeStore.DTOs.Category;
using PerfumeStore.Models;

namespace PerfumeStore.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllPerfumeCategories();
        Task<CategoryDTO> AddPerfumeCategory(AddCategoryDTO dto);
        Task<CategoryDTO> GetPerfumeCategoryById(int Id);
        Task<CategoryDTO> UpdatePerfumeCategory(int Id, UpdateCategoryDTO dto);
        Task DeletePerfumeCategory(int Id);
    }
}
