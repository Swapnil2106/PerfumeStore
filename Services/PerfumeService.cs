using Microsoft.EntityFrameworkCore;
using PerfumeStore.Data;
using PerfumeStore.DTOs;
using PerfumeStore.Models;

namespace PerfumeStore.Services
{
    public class PerfumeService: IPerfumeService
    {
        private readonly ApplicationDbContext dbContext;

        public PerfumeService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;            
        }

        public async Task<IEnumerable<PerfumeDTO>> GetAllPerfumes()
        {
            var perfumesList = await dbContext.Perfumes
                .AsNoTracking()
                .Include(p => p.PerfumeCategory)
                .Include(p => p.PerfumeType)
                .Select(p => new PerfumeDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.PerfumeCategory.Name,
                    Type = p.PerfumeType.Name
                }).ToListAsync();

            return perfumesList;
        }

        public async Task<PerfumeDTO> AddPerfume(AddPerfumeDTO dto)
        {
            var createPerfume = new Perfume
            {
                Name = dto.Name,
                Price = dto.Price,
                PerfumeCategoryId = dto.PerfumeCategoryId,
                PerfumeTypeId = dto.PerfumeTypeId
            };

            dbContext.Perfumes.Add(createPerfume);
            await dbContext.SaveChangesAsync();

            var category = await dbContext.PerfumeCategories.FirstOrDefaultAsync(pc => pc.Id == dto.PerfumeCategoryId);
            var type = await dbContext.PerfumeTypes.FirstOrDefaultAsync(pt => pt.Id == dto.PerfumeTypeId);

            return new PerfumeDTO
            {
                Id = createPerfume.Id,
                Name = createPerfume.Name,
                Price = createPerfume.Price,
                Category = category.Name,
                Type = type.Name
            };
        }
    }
}
