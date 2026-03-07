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
                .Include(p => p.Category)
                .Include(p => p.Type)
                .Select(p => new PerfumeDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,                    
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Name,
                    Type = p.Type.Name
                }).ToListAsync();

            return perfumesList;
        }

        public async Task<PerfumeDTO> AddPerfume(AddPerfumeDTO dto)
        {
            var createPerfume = new Perfume
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.PerfumeCategoryId,
                TypeId = dto.PerfumeTypeId
            };

            dbContext.Perfumes.Add(createPerfume);
            await dbContext.SaveChangesAsync();

            //to avoid null reference error at line no 57 & 58
            var category = await dbContext.Categories.FirstOrDefaultAsync(pc => pc.Id == dto.PerfumeCategoryId);
            var type = await dbContext.Types.FirstOrDefaultAsync(pt => pt.Id == dto.PerfumeTypeId);

            return new PerfumeDTO
            {
                Id = createPerfume.Id,
                Name = createPerfume.Name,
                Description = createPerfume.Description,
                Price = createPerfume.Price,
                StockQuantity = createPerfume.StockQuantity,
                ImageUrl = createPerfume.ImageUrl,
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
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Name,
                    Type = p.Type.Name
                })
                .FirstOrDefaultAsync();

            return perfume;
        }

        public async Task<PerfumeDTO> UpdatePerfume(int id, UpdatePerfumeDTO dto)
        {
            //Here we cannot use use the above existing method to fetch the details as it has asNoTracking method.
            var perfumeEntity = await dbContext.Perfumes.FirstOrDefaultAsync(pc => pc.Id == id);

            perfumeEntity.Name = dto.Name;
            perfumeEntity.Description = dto.Description;
            perfumeEntity.Price = dto.Price;
            perfumeEntity.StockQuantity = dto.StockQuantity;
            perfumeEntity.ImageUrl = dto.ImageUrl;
            perfumeEntity.CategoryId = dto.PerfumeCategoryId;
            perfumeEntity.TypeId = dto.PerfumeTypeId;
            await dbContext.SaveChangesAsync();

            var updatedPerfume = await dbContext.Perfumes
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new PerfumeDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                ImageUrl = p.ImageUrl,
                Category = p.Category.Name,
                Type = p.Type.Name
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
