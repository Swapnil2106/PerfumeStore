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
    }
}
