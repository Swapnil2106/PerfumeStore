using PerfumeStore.DTOs;

namespace PerfumeStore.Services
{
    public interface IPerfumeTypeService
    {
        Task<IEnumerable<PerfumeTypeDTO>> GetAllPerfumeTypes();
        Task<PerfumeTypeDTO> AddPerfumeType(AddPerfumeTypeDTO dto);
        Task<PerfumeTypeDTO> GetPerfumeTypeById(int id);
        Task<PerfumeTypeDTO> UpdatePerfumeType(int Id, UpdatePerfumeTypeDTO dto);
        Task DeletePerfumeType(int Id);
    }
}
