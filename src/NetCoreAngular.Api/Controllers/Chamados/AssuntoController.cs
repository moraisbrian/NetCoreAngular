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
    public class AssuntoController : ControllerBase
    {
        private readonly IAssuntoService _assuntoService;
        public AssuntoController(IAssuntoService assuntoService)
        {
            _assuntoService = assuntoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterAssuntos()
        {
            try
            {
                var assuntos = await _assuntoService.Consultar();
                return Ok(assuntos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{departamentoId}")]
        public async Task<IActionResult> obterAssuntosPorDepartamento(string departamentoId)
        {
            try 
            {
                var assuntos = await _assuntoService.ObterAssuntosPorDepartamento(departamentoId);
                return Ok(assuntos);
            }   
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}