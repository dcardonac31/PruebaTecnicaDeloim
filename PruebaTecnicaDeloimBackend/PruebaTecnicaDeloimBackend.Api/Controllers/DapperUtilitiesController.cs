using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnicaDeloimBackend.Common.Dtos;
using PruebaTecnicaDeloimBackend.Common.Enums;
using PruebaTecnicaDeloimBackend.Common.Enums.Exts;
using PruebaTecnicaDeloimBackend.Domain.Dtos;
using PruebaTecnicaDeloimBackend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PruebaTecnicaDeloimBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperUtilitiesController : ControllerBase
    {
        private readonly IDapperUtilitiesService _service;
        private readonly ILogger<DapperUtilitiesController> _logger;

        public DapperUtilitiesController(IDapperUtilitiesService service, ILogger<DapperUtilitiesController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GetListAfiliado/{city}/{year:int}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseService<IEnumerable<AfiliadoDto>>), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(int))]
        public async Task<IActionResult> GetListAfiliado(string city, int year)
        {
            if (city is null || city == " ")
                city = "";


            _logger.LogInformation(nameof(GetListAfiliado));

            var result = await _service.GetListAfiliado(city, year);
            var resultDto = result as AfiliadoDto[] ?? result.ToArray();
            var response = new ResponseService<IEnumerable<AfiliadoDto>>
            {
                Status = resultDto.Any(),
                Message = resultDto.Any() ? GenericEnumerator.Status.Ok.ToStringAttribute() : GenericEnumerator.Status.Error.ToStringAttribute(),
                Data = resultDto
            };
            return Ok(response);
        }

    }
}
