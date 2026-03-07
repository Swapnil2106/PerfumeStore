using Microsoft.EntityFrameworkCore;
using PerfumeStore.Data;
using PerfumeStore.DTOs;
using PerfumeStore.Models;

namespace PerfumeStore.Services
{
    public class TypeService: ITypeService
    {
        private readonly ApplicationDbContext dbContext;

        public TypeService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IEnumerable<TypeDTO>> GetAllPerfumeTypes()
        {
            var PerfumeTypeList = await dbContext.Types
                .AsNoTracking()
                .Select(pt => new TypeDTO
                {
                    Id = pt.Id,
                    Name = pt.Name
                }).ToListAsync();

            return PerfumeTypeList;
        }

        public async Task<TypeDTO> AddPerfumeType(AddTypeDTO dto)
        {
            var perfumeType = new Models.Type
            {
                Name = dto.Name
            };
            dbContext.Types.Add(perfumeType);
            await dbContext.SaveChangesAsync();

            return new TypeDTO
            {
                Id = perfumeType.Id,
                Name = perfumeType.Name
            };
        }

        public async Task<TypeDTO> GetPerfumeTypeById(int id)
        {
            var perfumeType = await dbContext.Types.AsNoTracking().FirstOrDefaultAsync(pt => pt.Id == id);

            return new TypeDTO
            {
                Id = perfumeType.Id,
                Name = perfumeType.Name
            };
        }

        public async Task<TypeDTO> UpdatePerfumeType(int id, UpdateTypeDTO dto)
        {
            //Here we cannot use use the above existing method to fetch the details as it has asNoTracking method.
            var perfumeTypeEntity = await dbContext.Types.FirstOrDefaultAsync(pc => pc.Id == id);

            perfumeTypeEntity.Name = dto.Name;
            await dbContext.SaveChangesAsync();

            return new TypeDTO
            {
                Id = perfumeTypeEntity.Id,
                Name = perfumeTypeEntity.Name
            };
        }

        public async Task DeletePerfumeType(int id)
        {
            var type = await dbContext.Types.FirstOrDefaultAsync(c => c.Id == id);

            var isUsed = await dbContext.Perfumes.AnyAsync(p => p.PerfumeTypeId == id);
            if (isUsed)
                throw new InvalidOperationException("Cannot delete type. It is associated with existing perfumes.");

            dbContext.Types.Remove(type);
            await dbContext.SaveChangesAsync();
        }
    }
}
