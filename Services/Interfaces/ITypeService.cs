using PerfumeStore.DTOs.Type;

namespace PerfumeStore.Services.Interfaces
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
