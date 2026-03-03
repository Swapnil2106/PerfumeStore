using PerfumeStore.DTOs;

namespace PerfumeStore.Services
{
    public interface IPerfumeService
    {
        Task<IEnumerable<PerfumeDTO>> GetAllPerfumes();
    }
}
