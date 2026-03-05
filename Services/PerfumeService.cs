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

            //to avoid null reference error at line no 57 & 58
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

        public async Task<PerfumeDTO> GetPerfumeById(int id)
        {
            var perfume = await dbContext.Perfumes
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select( p => new PerfumeDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.PerfumeCategory.Name,
                    Type = p.PerfumeType.Name
                })
                .FirstOrDefaultAsync();

            return perfume;
        }

        public async Task<PerfumeDTO> UpdatePerfume(int id, UpdatePerfumeDTO dto)
        {
            //Here we cannot use use the above existing method to fetch the details as it has asNoTracking method.
            var perfumeEntity = await dbContext.Perfumes.FirstOrDefaultAsync(pc => pc.Id == id);

            perfumeEntity.Name = dto.Name;
            perfumeEntity.Price = dto.Price;
            perfumeEntity.PerfumeCategoryId = dto.PerfumeCategoryId;
            perfumeEntity.PerfumeTypeId = dto.PerfumeTypeId;
            await dbContext.SaveChangesAsync();

            var updatedPerfume = await dbContext.Perfumes
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new PerfumeDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.PerfumeCategory.Name,
                Type = p.PerfumeType.Name
            })
            .FirstOrDefaultAsync();

                return updatedPerfume;
        }

        public async Task DeletePerfume(int id)
        {
            var perfume = await dbContext.Perfumes.FirstOrDefaultAsync(c => c.Id == id);

            dbContext.Perfumes.Remove(perfume);
            await dbContext.SaveChangesAsync();
        }
    }
}
