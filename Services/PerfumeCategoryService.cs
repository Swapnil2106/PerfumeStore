using Microsoft.EntityFrameworkCore;
using PerfumeStore.Data;
using PerfumeStore.DTOs;

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
    }
}
