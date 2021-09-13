using PruebaTecnicaDeloimBackend.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaDeloimBackend.Domain.Interfaces
{
    public interface IAfiliadoService
    {
        Task<AfiliadoDto> GetByIdAsync(int id);
        Task<IEnumerable<AfiliadoDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);
        (bool status, int id) Post(AfiliadoDto entity);
        Task<bool> PutAsync(int id, AfiliadoDto entity);
        Task<bool> DeleteAsync(int id);
    }
}
