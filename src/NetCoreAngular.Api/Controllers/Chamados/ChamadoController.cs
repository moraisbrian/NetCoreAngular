using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.Application.DTOs.Chamados;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NetCoreAngular.Application.Interfaces.Services.Chamados;

namespace NetCoreAngular.Api.Controllers.Chamados
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;

        public ChamadoController(IChamadoService cadastroChamadoService)
        {
            _chamadoService = cadastroChamadoService;
        }

        [HttpPost]
        public async Task<IActionResult> NovoChamado([FromBody] ChamadoDTO chamadoDto)
        {
            try
            {
                var chamado = await _chamadoService.Cadastrar(chamadoDto);
                return Ok(chamado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarChamado(string id, [FromBody] ChamadoDTO chamadoDto)
        {
            try
            {
                await _chamadoService.Atualizar(id, chamadoDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterChamados()
        {
            try
            {
                var chamados = await _chamadoService.Consultar();
                    
                return Ok(chamados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterChamado(string id) 
        {
            try
            {
                var chamado = await _chamadoService.Consultar(id);
                
                return Ok(chamado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}