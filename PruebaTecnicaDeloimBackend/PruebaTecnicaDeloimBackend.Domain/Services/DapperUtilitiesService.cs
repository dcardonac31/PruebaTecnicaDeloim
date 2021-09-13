using AutoMapper;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaDeloimBackend.Common.Dapper;
using PruebaTecnicaDeloimBackend.Common.Resources;
using PruebaTecnicaDeloimBackend.Domain.Dtos;
using PruebaTecnicaDeloimBackend.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaDeloimBackend.Domain.Services
{
    public class DapperUtilitiesService : IDapperUtilitiesService
    {
        private readonly IDapperHelper _dapperHelper;
        private readonly IConfiguration _configuration;

        public DapperUtilitiesService(IDapperHelper dapperHelper, IConfiguration configuration)
        {
            _dapperHelper = dapperHelper ?? throw new System.ArgumentNullException(nameof(dapperHelper));
            _configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<AfiliadoDto>> GetListAfiliado(string city, int year)
        {
            var query = StoredProceduresResource.GetListAfiliado;
            var filter = new { City = city, Year = year };

            var result = await _dapperHelper.ExecuteStoreProcedure<AfiliadoDto>(
                                _configuration.GetConnectionString("ConnectBDAfiliado"), query, filter);

            return Mapper.Map<IEnumerable<AfiliadoDto>>(result);
        }
    }
}
