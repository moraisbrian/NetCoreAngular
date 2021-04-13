using NetCoreAngular.Application.DTOs.Chamados;
using NetCoreAngular.Domain.Entidades;
using NetCoreAngular.Domain.Entidades.Chamados;
using NetCoreAngular.Domain.Enums.Chamados;
using NetCoreAngular.Domain.Interfaces.Repositorios;
using NetCoreAngular.Application.Interfaces.Services.Chamados;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace NetCoreAngular.Application.Services.Chamados
{
    public class CadastroChamadoService : IChamadoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CadastroChamadoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ChamadoDTO> Cadastrar(ChamadoDTO chamadoDto)
        {
            Usuario cliente = null;
            Assunto assunto = null;
            Departamento departamento = null;
            Franquia franquia = null;

            cliente = await _unitOfWork.UsuarioRepositorio.Consultar(chamadoDto.ClienteId);
            assunto = await _unitOfWork.AssuntoRepositorio.Consultar(chamadoDto.AssuntoId);
            franquia = await _unitOfWork.FranquiaRepositorio.ConsultarPorId(chamadoDto.FranquiaId);

            if (assunto != null)
            {
                departamento = await _unitOfWork.DepartamentoRepositorio
                    .Consultar(assunto.DepartamentoId);
            }

            if (cliente != null && departamento != null && franquia != null)
            {
                var chamado = new Chamado();
                chamado.AssuntoId = assunto.Id;
                chamado.Assunto = assunto;
                chamado.ClienteId = cliente.Id;
                chamado.PrioridadeId = chamadoDto.PrioridadeId;
                chamado.Situacao = Situacao.AguardandoRespostaAtendente;
                chamado.Status = Status.EmProcesso;
                chamado.DepartamentoId = departamento.Id;
                chamado.Departamento = departamento;
                chamado.DataAbertura = DateTime.Now;
                chamado.DataUltimaInteracao = DateTime.Now;
                chamado.Protocolo = await GerarProtocolo();
                chamado.FranquiaId = franquia.Id;

                var mensagem = new Mensagem();
                mensagem.Conteudo = chamadoDto.MensagemInicial;
                mensagem.ChamadoId = chamado.Id;
                mensagem.Chamado = chamado;
                mensagem.UsuarioId = cliente.Id;
                mensagem.Usuario = cliente;
                mensagem.DataCriacao = DateTime.Now;

                chamado.Mensagens.Add(mensagem);

                await _unitOfWork.ChamadoRepositorio.Adicionar(chamado);
                await _unitOfWork.MensagemRepositorio.Adicionar(mensagem);
                await _unitOfWork.Commit();

                return _mapper.Map<ChamadoDTO>(chamado);
            }
            else 
            {
                return null;
            }
        }

        public async Task Atualizar(string id, ChamadoDTO chamadoDto)
        {
            var chamado = await _unitOfWork.ChamadoRepositorio.Consultar(id);

            if (chamado != null)
            {
                if (!string.IsNullOrEmpty(chamadoDto.ClienteId))
                {
                    var cliente = await _unitOfWork.UsuarioRepositorio.Consultar(chamadoDto.ClienteId);
                    chamado.ClienteId = cliente.Id;
                }

                if (!string.IsNullOrEmpty(chamadoDto.AtendenteId))
                {
                    var atendente = await _unitOfWork.UsuarioRepositorio.Consultar(chamadoDto.AtendenteId);
                    chamado.AtendenteId = atendente.Id;
                }
                
                chamado.AssuntoId = chamadoDto.AssuntoId;
                chamado.DataUltimaInteracao = DateTime.Now;
                chamado.DepartamentoId = chamadoDto.DepartamentoId;
                chamado.NotaAvaliacaoId = chamadoDto.NotaAvaliacaoId;
                chamado.ObservacoesEncerramento = chamadoDto.ObservacoesEncerramento;
                chamado.PrioridadeId = chamadoDto.PrioridadeId;
                chamado.Situacao = chamadoDto.Situacao;
                chamado.Status = chamadoDto.Status;

                await _unitOfWork.Commit();
            }
        }

        public async Task<IEnumerable<ChamadoDTO>> Consultar()
        {
            var chamados = await _unitOfWork.ChamadoRepositorio.Consultar();

            return _mapper.Map<IEnumerable<ChamadoDTO>>(chamados);
        }

        public async Task<ChamadoDTO> Consultar(string id)
        {
            var chamado = await _unitOfWork.ChamadoRepositorio.Consultar(id);

            return _mapper.Map<ChamadoDTO>(chamado);
        }

        private async Task<string> GerarProtocolo()
        {
            var protocolo = await _unitOfWork.ProtocoloRepositorio.Consultar();

            if (protocolo == null) 
            {
                protocolo = new Protocolo();
                protocolo.Numero = 0;
                await _unitOfWork.ProtocoloRepositorio.Salvar(protocolo);
            }
            
            protocolo.Numero++;
            await _unitOfWork.Commit();
            var protocoloFormatado = DateTime.Now.Year.ToString().Substring(2);
            protocoloFormatado += DateTime.Now.Month.ToString().Length == 1 ? string.Format("0{0}", DateTime.Now.Month.ToString()) : DateTime.Now.Month.ToString();
            protocoloFormatado += DateTime.Now.Day.ToString().Length == 1 ? string.Format("0{0}", DateTime.Now.Day.ToString()) : DateTime.Now.Day.ToString();
            protocoloFormatado += DateTime.Now.Hour.ToString().Length == 1 ? string.Format("0{0}", DateTime.Now.Hour.ToString()) : DateTime.Now.Hour.ToString();
            protocoloFormatado += DateTime.Now.Minute.ToString().Length == 1 ? string.Format("0{0}", DateTime.Now.Minute.ToString()) : DateTime.Now.Minute.ToString();
            protocoloFormatado += protocolo.Numero.ToString().Length < 6 ? new string('0', 6 - protocolo.Numero.ToString().Length) + protocolo.Numero.ToString() : protocolo.Numero.ToString();

            return protocoloFormatado;
        }
    }
}