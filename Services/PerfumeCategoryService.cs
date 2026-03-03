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

        public async Task<PerfumeCategoryDTO> AddPerfumeCategory(AddPerfumeCategoryDTO dto)
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

        public async Task<PerfumeCategoryDTO> GetPerfumeCategoryById(int id)
        {
            var perfumeCategory = await dbContext.PerfumeCategories.AsNoTracking().FirstOrDefaultAsync(pc => pc.Id == id);

            return new PerfumeCategoryDTO
            {
                Id = perfumeCategory.Id,
                Name = perfumeCategory.Name
            };
        }

        public async Task<PerfumeCategoryDTO> UpdatePerfumeCategory(int id, UpdatePerfumeCategoryDTO dto)
        {
            //Here we cannot use use the above existing method to fetch the details as it has asNoTracking method.
            var perfumeCategoryEntity = await dbContext.PerfumeCategories.FirstOrDefaultAsync(pc => pc.Id == id); 

            perfumeCategoryEntity.Name = dto.Name;
            await dbContext.SaveChangesAsync();

            return new PerfumeCategoryDTO
            {
                Id = perfumeCategoryEntity.Id,
                Name = perfumeCategoryEntity.Name
            };
        }
    }
}
