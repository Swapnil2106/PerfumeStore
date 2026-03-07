using Microsoft.EntityFrameworkCore;
using PerfumeStore.Data;
using PerfumeStore.DTOs;
using PerfumeStore.Models;

namespace PerfumeStore.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllPerfumeCategories()
        {
            var perfumeCategoriesList = await dbContext.Categories
                .AsNoTracking()
                .Select(pc => new CategoryDTO
                {
                    Id = pc.Id,
                    Name = pc.Name
                }).ToListAsync();

            return perfumeCategoriesList;
        }

        public async Task<CategoryDTO> AddPerfumeCategory(AddCategoryDTO dto)
        {
            var perfumeCategory = new Category
            {
                Name = dto.Name
            };
            dbContext.Categories.Add(perfumeCategory);
            await dbContext.SaveChangesAsync();

            return new CategoryDTO
            {
                Id = perfumeCategory.Id,
                Name = perfumeCategory.Name
            };
        }

        public async Task<CategoryDTO> GetPerfumeCategoryById(int id)
        {
            var perfumeCategory = await dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(pc => pc.Id == id);

            return new CategoryDTO
            {
                Id = perfumeCategory.Id,
                Name = perfumeCategory.Name
            };
        }

        public async Task<CategoryDTO> UpdatePerfumeCategory(int id, UpdateCategoryDTO dto)
        {
            //Here we cannot use use the above existing method to fetch the details as it has asNoTracking method.
            var perfumeCategoryEntity = await dbContext.Categories.FirstOrDefaultAsync(pc => pc.Id == id); 

            perfumeCategoryEntity.Name = dto.Name;
            await dbContext.SaveChangesAsync();

            return new CategoryDTO
            {
                Id = perfumeCategoryEntity.Id,
                Name = perfumeCategoryEntity.Name
            };
        }

        public async Task DeletePerfumeCategory(int id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            var isUsed = await dbContext.Perfumes.AnyAsync(p => p.CategoryId == id);
            if (isUsed)
                throw new InvalidOperationException("Cannot delete category. It is associated with existing perfumes.");

            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
        }

    }
}
