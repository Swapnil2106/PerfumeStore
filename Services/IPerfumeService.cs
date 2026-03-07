using PerfumeStore.DTOs.Perfume;

namespace PerfumeStore.Services
{
    public interface IPerfumeService
    {
        Task<IEnumerable<PerfumeDTO>> GetAllPerfumes();
        Task<PerfumeDTO> AddPerfume(AddPerfumeDTO dto);
        Task<PerfumeDTO> GetPerfumeById(int id);
        Task<PerfumeDTO> UpdatePerfume(int Id, UpdatePerfumeDTO dto);
        Task DeletePerfume(int Id);
    }
}
