using Microsoft.EntityFrameworkCore;
using PerfumeStore.Data;
using PerfumeStore.DTOs;

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
            var PerfumesList = await dbContext.Perfumes
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

            return PerfumesList;
        }
    }
}
