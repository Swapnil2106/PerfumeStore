using Microsoft.EntityFrameworkCore;
using PerfumeStore.Data;
using PerfumeStore.DTOs;
using PerfumeStore.Models;

namespace PerfumeStore.Services
{
    public class PerfumeCategoryService: IPerfumeCategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public PerfumeCategoryService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IEnumerable<PerfumeCategoryDTO>> GetAllPerfumeCategories()
        {
            var perfumeCategoriesList = await dbContext.PerfumeCategories
                .AsNoTracking()
                .Select(pc => new PerfumeCategoryDTO
                {
                    Id = pc.Id,
                    Name = pc.Name
                }).ToListAsync();

            return perfumeCategoriesList;
        }

        public async Task<PerfumeCategoryDTO> CreatePerfumeCategory(CreatePerfumeCategoryDTO dto)
        {
            var perfumeCategory = new PerfumeCategory
            {
                Name = dto.Name
            };
            dbContext.PerfumeCategories.Add(perfumeCategory);
            await dbContext.SaveChangesAsync();

            return new PerfumeCategoryDTO
            {
                Id = perfumeCategory.Id,
                Name = perfumeCategory.Name
            };
        }
    }
}
