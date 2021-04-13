using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.Api.Config;
using NetCoreAngular.Api.ViewModels;
using NetCoreAngular.Application.Interfaces.Services;

namespace NetCoreAngular.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{departamentoId}")]
        public async Task<IActionResult> ObterUsuariosPorDepartamento(string departamentoId)
        {
            try
            {
                var result = await _usuarioService.ObterUsuariosPorDepartamento(departamentoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AlterarSenha(AlterarSenhaViewModel alterarSenha)
        {
            try 
            {
                var novaSenhaHash = Criptografia.GerarHash(alterarSenha.SenhaNova);
                var antigaSenhaHash = Criptografia.GerarHash(alterarSenha.SenhaAntiga);
                var result = await _usuarioService.AlterarSenha(alterarSenha.UsuarioId, antigaSenhaHash, novaSenhaHash);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}