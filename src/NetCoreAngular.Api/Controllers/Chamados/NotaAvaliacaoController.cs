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
    public class NotaAvaliacaoController : ControllerBase
    {
        private readonly INotaAvaliacaoService _notaService;
        public NotaAvaliacaoController(INotaAvaliacaoService notaService)
        {
            _notaService = notaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterNotas()
        {
            try
            {
                var mensagens = await _notaService.Consultar();
                return Ok(mensagens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}