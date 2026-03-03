using PerfumeStore.DTOs;

namespace PerfumeStore.Services
{
    public interface IPerfumeTypeService
    {
        Task<IEnumerable<PerfumeTypeDTO>> GetAllPerfumeTypes();
        Task<PerfumeTypeDTO> AddPerfumeType(AddPerfumeTypeDTO dto);
    }
}
