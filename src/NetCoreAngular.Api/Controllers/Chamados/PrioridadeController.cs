using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.Application.Interfaces.Services.Chamados;

namespace NetCoreAngular.Api.Controllers.Chamados
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PrioridadeController : ControllerBase
    {
        private readonly IPrioridadeService _prioridadeService;
        public PrioridadeController(IPrioridadeService prioridadeService)
        {
            _prioridadeService = prioridadeService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterPrioridades()
        {
            try
            {
                var prioridades = await _prioridadeService.Consultar();
                return Ok(prioridades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}