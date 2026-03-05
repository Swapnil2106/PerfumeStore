using Microsoft.EntityFrameworkCore;
using PerfumeStore.Data;
using PerfumeStore.DTOs;
using PerfumeStore.Models;

namespace PerfumeStore.Services
{
    public class PerfumeTypeService: IPerfumeTypeService
    {
        private readonly ApplicationDbContext dbContext;

        public PerfumeTypeService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IEnumerable<PerfumeTypeDTO>> GetAllPerfumeTypes()
        {
            var PerfumeTypeList = await dbContext.PerfumeTypes
                .AsNoTracking()
                .Select(pt => new PerfumeTypeDTO
                {
                    Id = pt.Id,
                    Name = pt.Name
                }).ToListAsync();

            return PerfumeTypeList;
        }

        public async Task<PerfumeTypeDTO> AddPerfumeType(AddPerfumeTypeDTO dto)
        {
            var perfumeType = new PerfumeType
            {
                Name = dto.Name
            };
            dbContext.PerfumeTypes.Add(perfumeType);
            await dbContext.SaveChangesAsync();

            return new PerfumeTypeDTO
            {
                Id = perfumeType.Id,
                Name = perfumeType.Name
            };
        }

        public async Task<PerfumeTypeDTO> GetPerfumeTypeById(int id)
        {
            var perfumeType = await dbContext.PerfumeTypes.AsNoTracking().FirstOrDefaultAsync(pt => pt.Id == id);

            return new PerfumeTypeDTO
            {
                Id = perfumeType.Id,
                Name = perfumeType.Name
            };
        }

        public async Task<PerfumeTypeDTO> UpdatePerfumeType(int id, UpdatePerfumeTypeDTO dto)
        {
            //Here we cannot use use the above existing method to fetch the details as it has asNoTracking method.
            var perfumeTypeEntity = await dbContext.PerfumeTypes.FirstOrDefaultAsync(pc => pc.Id == id);

            perfumeTypeEntity.Name = dto.Name;
            await dbContext.SaveChangesAsync();

            return new PerfumeTypeDTO
            {
                Id = perfumeTypeEntity.Id,
                Name = perfumeTypeEntity.Name
            };
        }

        public async Task DeletePerfumeType(int id)
        {
            var type = await dbContext.PerfumeTypes.FirstOrDefaultAsync(c => c.Id == id);

            var isUsed = await dbContext.Perfumes.AnyAsync(p => p.PerfumeTypeId == id);
            if (isUsed)
                throw new InvalidOperationException("Cannot delete type. It is associated with existing perfumes.");

            dbContext.PerfumeTypes.Remove(type);
            await dbContext.SaveChangesAsync();
        }
    }
}
