using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs.Chamados;
using NetCoreAngular.Domain.Entidades;
using NetCoreAngular.Domain.Entidades.Chamados;
using NetCoreAngular.Application.Interfaces.Utils;
using NetCoreAngular.Domain.Interfaces.Repositorios;
using NetCoreAngular.Application.Interfaces.Services.Chamados;
using AutoMapper;

namespace NetCoreAngular.Application.Services.Chamados
{
    public class CadastroMensagemService : IMensagemService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoogleDrive _googleDriveServices;
        private readonly IArquivosPasta _arquivosPasta;

        public CadastroMensagemService(
            IUnitOfWork unitOfWork, 
            IGoogleDrive googleDriveServices, 
            IArquivosPasta arquivosPasta,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _googleDriveServices = googleDriveServices;
            _arquivosPasta = arquivosPasta;
            _mapper = mapper;
        }

        public async Task<string> Cadastrar(MensagemDTO mensagemDto)
        {
            var chamado = await _unitOfWork.ChamadoRepositorio.Consultar(mensagemDto.ChamadoId);
            var usuario = await _unitOfWork.UsuarioRepositorio.Consultar(mensagemDto.UsuarioId);

            if (chamado != null && usuario != null && !string.IsNullOrEmpty(mensagemDto.Conteudo))
            {
                var mensagem = new Mensagem();
                mensagem.Conteudo = mensagemDto.Conteudo;
                mensagem.ChamadoId = mensagemDto.ChamadoId;
                mensagem.DataCriacao = DateTime.Now;
                mensagem.UsuarioId = mensagemDto.UsuarioId;

                await _unitOfWork.MensagemRepositorio.Adicionar(mensagem);
                await _unitOfWork.Commit();

                return mensagem.Id;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<ArquivoChamadoDTO>> ObterArquivosGoogleDrive(string mensagemId)
        {
            var arquivos = await _googleDriveServices.Download(mensagemId);

            var arquivosChamado = new List<ArquivoChamadoDTO>();
            if (arquivos != null && arquivos.Any())
            {
                foreach (var arquivo in arquivos)
                {
                    arquivosChamado.Add(new ArquivoChamadoDTO
                    {
                        MensagemId = mensagemId,
                        ConteudoByte = ((MemoryStream)arquivo.Item2).ToArray(),
                        Nome = arquivo.Item1,
                        Tamanho = arquivo.Item1.Length
                    });
                }
            }

            return arquivosChamado;
        }

        public async Task<IEnumerable<ArquivoChamadoDTO>> ObterArquivosBanco(string mensagemId)
        {
            var arquivos = await _unitOfWork.ArquivoRepositorio.Consultar(mensagemId);

            var arquivosChamado = new List<ArquivoChamadoDTO>();
            foreach (var arquivo in arquivos)
            {
                arquivosChamado.Add(new ArquivoChamadoDTO
                {
                    Id = arquivo.Id,
                    MensagemId = arquivo.IdPai,
                    Nome = arquivo.Nome,
                    ConteudoByte = arquivo.Conteudo
                });
            }

            return arquivosChamado;
        }

        public async Task SalvarArquivosGoogleDrive(string mensagemId, List<ArquivoChamadoDTO> arquivos)
        {
            var mensagem = await _unitOfWork.MensagemRepositorio.Consultar(mensagemId);
            if (mensagem != null && arquivos.Count > 0)
            {
                foreach (var arquivo in arquivos)
                {
                    await _googleDriveServices.Upload(arquivo.Nome, arquivo.ConteudoStream, mensagemId);
                }
            }
        }

        public async Task SalvarArquivosPasta(string mensagemId, List<ArquivoChamadoDTO> arquivos)
        {
            var mensagem = await _unitOfWork.MensagemRepositorio.Consultar(mensagemId);
            if (mensagem != null && arquivos.Count > 0)
            {
                foreach (var arquivo in arquivos)
                {
                    _arquivosPasta.SalvarArquivo(
                        arquivo.Nome,
                        mensagemId,
                        ((MemoryStream)arquivo.ConteudoStream).ToArray()
                    );
                }
            }
        }

        public IEnumerable<ArquivoChamadoDTO> ObterArquivosPasta(string mensagemId)
        {
            var arquivos = _arquivosPasta.ObterArquivos(mensagemId);

            var arquivosChamado = new List<ArquivoChamadoDTO>();
            foreach (var arquivo in arquivos)
            {
                var ms = new MemoryStream();
                arquivo.Item2.CopyTo(ms);
                arquivosChamado.Add(new ArquivoChamadoDTO
                {
                    Nome = arquivo.Item1,
                    ConteudoByte = ms.ToArray()
                });
            }

            return arquivosChamado;
        }

        public async Task SalvarArquivosBanco(string mensagemId, List<ArquivoChamadoDTO> arquivos)
        {
            var mensagem = await _unitOfWork.MensagemRepositorio.Consultar(mensagemId);
            if (mensagem != null && arquivos.Count > 0)
            {
                foreach (var arquivo in arquivos)
                {
                    await _unitOfWork.ArquivoRepositorio.Adicionar(new Arquivo
                    {
                        IdPai = mensagemId,
                        Nome = arquivo.Nome,
                        Conteudo = ((MemoryStream)arquivo.ConteudoStream).ToArray()
                    });
                }

                await _unitOfWork.Commit();
            }
        }

        public async Task<IEnumerable<MensagemDTO>> ConsultarPorChamado(string id)
        {
            var mensagens = await _unitOfWork.MensagemRepositorio.ConsultarPorChamado(id);

            return _mapper.Map<IEnumerable<MensagemDTO>>(mensagens);
        }
    }
}