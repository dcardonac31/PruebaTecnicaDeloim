using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnicaDeloimBackend.Api.Models;
using PruebaTecnicaDeloimBackend.Common.Dtos;
using PruebaTecnicaDeloimBackend.Common.Enums;
using PruebaTecnicaDeloimBackend.Common.Enums.Exts;
using PruebaTecnicaDeloimBackend.Domain.Dtos;
using PruebaTecnicaDeloimBackend.Domain.Interfaces;
using Shyjus.BrowserDetection;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaDeloimBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfiliadosController : ControllerBase
    {
        private readonly ILogger<AfiliadosController> _logger;
        private readonly IAfiliadoService _service;
        private readonly IBrowserDetector _browserDetector;

        public AfiliadosController(ILogger<AfiliadosController> logger, IAfiliadoService service, IBrowserDetector browserDetector)
        {
            _logger = logger;
            _service = service;
            _browserDetector = browserDetector;
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseService<AfiliadoDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            _logger.LogInformation(nameof(GetByIdAsync));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _service.GetByIdAsync(id).ConfigureAwait(false);
            result.FotoBase64 = Encoding.UTF8.GetString(result.Foto);
            var existResult = result != null;
            var response = new ResponseService<AfiliadoDto>
            {
                Status = existResult,
                Message = existResult ? GenericEnumerator.Status.Ok.ToStringAttribute() : GenericEnumerator.Status.Error.ToStringAttribute(),
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{page:int}/{limit:int}")]
        [ProducesResponseType(typeof(ResponseService<IEnumerable<AfiliadoDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync(int? page, int? limit)
        {
            _logger.LogInformation(nameof(GetAllAsync));

            var result = await _service.GetAllAsync(page ?? 1, limit ?? 1000, "AfiliadoID").ConfigureAwait(false);

            foreach (var item in result)
            {
                item.FotoBase64 = Encoding.UTF8.GetString(item.Foto);
            }

            var resultDtos = result as AfiliadoDto[] ?? result.ToArray();

            var response = new ResponseService<IEnumerable<AfiliadoDto>>
            {
                Status = resultDtos.Any(),
                Message = resultDtos.Any() ? GenericEnumerator.Status.Ok.ToStringAttribute() : GenericEnumerator.Status.Error.ToStringAttribute(),
                Data = resultDtos
            };

            return Ok(response);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseService<string>), (int)HttpStatusCode.Created)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(AfiliadoModel))]
        public IActionResult Post([FromBody] AfiliadoDto request)
        {
            _logger.LogInformation(nameof(Post));

            request.Foto = System.Text.Encoding.UTF8.GetBytes(request.FotoBase64);

            var objRequest = Mapper.Map<AfiliadoDto>(request);

            var (status, id) = _service.Post(objRequest);

            return Ok(new ResponseService<int>
            {
                Status = status,
                Data = status ? id : default
            });
        }

        [HttpPut("{id}")]
        [DisableRequestSizeLimit]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseService<bool>), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(AfiliadoModel))]
        public async Task<IActionResult> PutAsync(int id, [FromBody] AfiliadoDto request)
        {
            _logger.LogInformation(nameof(PutAsync));

            if (id != request.AfiliadoID)
                return BadRequest();

            request.Foto = System.Text.Encoding.UTF8.GetBytes(request.FotoBase64);

            var status = await _service.PutAsync(id, request).ConfigureAwait(false);

            var response = new ResponseService<bool>
            {
                Status = status
            };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseService<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation(nameof(DeleteAsync));

            var status = await _service.DeleteAsync(id).ConfigureAwait(false);

            var response = new ResponseService<bool>
            {
                Status = status
            };
            return Ok(response);
        }
    }
}
