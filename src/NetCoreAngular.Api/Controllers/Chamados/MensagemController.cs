using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.Application.DTOs.Chamados;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using NetCoreAngular.Application.Interfaces.Services.Chamados;

namespace NetCoreAngular.Api.Controllers.Chamados
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemService _mensagemService;

        public MensagemController(IMensagemService MensagemService)
        {
            _mensagemService = MensagemService;
        }

        [HttpPost]
        public async Task<IActionResult> NovaMensagem([FromBody] MensagemDTO mensagemDto)
        {
            try
            {
                var mensagemId = await _mensagemService.Cadastrar(mensagemDto);
                return Ok(JsonConvert.SerializeObject(mensagemId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{chamadoId}")]
        public async Task<IActionResult> ObterMensagens(string chamadoId)
        {
            try
            {
                var mensagens = await _mensagemService.ConsultarPorChamado(chamadoId);
                return Ok(mensagens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}