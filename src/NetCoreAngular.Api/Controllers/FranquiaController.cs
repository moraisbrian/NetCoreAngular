using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.Application.Interfaces.Services;

namespace NetCoreAngular.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FranquiaController : ControllerBase
    {
        private readonly IFranquiaService _franquiaService;
        public FranquiaController(IFranquiaService franquiaService)
        {
            _franquiaService = franquiaService;
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> ConsultarPorUsuario(string usuarioId)
        {
            try
            {
                var franquias = await _franquiaService.ConsultarPorUsuario(usuarioId);
                return Ok(franquias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}