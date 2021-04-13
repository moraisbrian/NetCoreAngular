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
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;
        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterDepartamentos()
        {
            try
            {
                var resultados = await _departamentoService.Consultar();
                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}