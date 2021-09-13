using PruebaTecnicaDeloimBackend.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaDeloimBackend.Domain.Interfaces
{
    public interface IDapperUtilitiesService
    {
        Task<IEnumerable<AfiliadoDto>> GetListAfiliado(string city, int year);
    }
}
