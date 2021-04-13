using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NetCoreAngular.Application.DTOs.Chamados;
using NetCoreAngular.Application.Interfaces.Services.Chamados;

namespace NetCoreAngular.Api.Controllers.Chamados
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArquivoChamadoController : ControllerBase
    {
        private readonly IMensagemService _mensagemService;
        private readonly IConfiguration _configuration;

        public ArquivoChamadoController(
            IConfiguration configuration,
            IMensagemService cadastroMensagemService
        )
        {
            _mensagemService = cadastroMensagemService;
            _configuration = configuration;
        }

        [HttpPost("{mensagemId}")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> AdicionarAnexo(string mensagemId)
        {
            try
            {
                var arquivos = Request.Form.Files;
                List<ArquivoChamadoDTO> arquivosDto = new List<ArquivoChamadoDTO>();

                if (arquivos.Count > 0) 
                {
                    foreach (var arquivo in arquivos)
                    {
                        if (arquivo.Length > 0)
                        {
                            var ms = new MemoryStream();
                            await arquivo.CopyToAsync(ms);
                            arquivosDto.Add(new ArquivoChamadoDTO
                            {
                                MensagemId = mensagemId,
                                Nome = arquivo.Name,
                                ConteudoStream = ms,
                                Tamanho = Convert.ToInt32(arquivo.Length)
                            });
                        }
                    }
                }

                if (arquivosDto.Count > 0)
                {
                    switch (_configuration["FileSettings:StorageType"])
                    {
                        case "GoogleDrive":
                            await _mensagemService.SalvarArquivosGoogleDrive(mensagemId, arquivosDto);
                            break;
                        case "Banco":
                            await _mensagemService.SalvarArquivosBanco(mensagemId, arquivosDto);
                            break;
                        case "Pasta":
                            await _mensagemService.SalvarArquivosPasta(mensagemId, arquivosDto);
                            break;
                    } 
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{mensagemId}")]
        public async Task<IActionResult> ObterAnexos(string mensagemId)
        {
            try
            {
                IEnumerable<ArquivoChamadoDTO> arquivos = new List<ArquivoChamadoDTO>();
                switch (_configuration["FileSettings:StorageType"])
                {
                    case "GoogleDrive":
                        arquivos = await _mensagemService.ObterArquivosGoogleDrive(mensagemId);
                        break;
                    case "Banco":
                        arquivos = await _mensagemService.ObterArquivosBanco(mensagemId);
                        break;
                    case "Pasta":
                        arquivos = _mensagemService.ObterArquivosPasta(mensagemId);
                        break;
                }

                return Ok(arquivos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}