using PerfumeStore.DTOs;

namespace PerfumeStore.Services
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeDTO>> GetAllPerfumeTypes();
        Task<TypeDTO> AddPerfumeType(AddTypeDTO dto);
        Task<TypeDTO> GetPerfumeTypeById(int id);
        Task<TypeDTO> UpdatePerfumeType(int Id, UpdateTypeDTO dto);
        Task DeletePerfumeType(int Id);
    }
}
