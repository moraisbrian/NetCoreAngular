using System.Collections.Generic;
using AutoMapper;
using NetCoreAngular.Application.DTOs;
using NetCoreAngular.Application.DTOs.Chamados;
using NetCoreAngular.Domain.Entidades;
using NetCoreAngular.Domain.Entidades.Chamados;

namespace NetCoreAngular.Application
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region Usuario
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario[], IEnumerable<UsuarioDTO>>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<UsuarioDTO[], IEnumerable<Usuario>>();
            #endregion
            
            #region Franquia
            CreateMap<Franquia, FranquiaDTO>();
            CreateMap<Franquia[], IEnumerable<FranquiaDTO>>();
            CreateMap<FranquiaDTO, Franquia>();
            CreateMap<FranquiaDTO[], IEnumerable<Franquia>>();
            #endregion
            
            #region Prioridade
            CreateMap<Prioridade, PrioridadeDTO>();
            CreateMap<Prioridade[], IEnumerable<PrioridadeDTO>>();
            CreateMap<PrioridadeDTO, Prioridade>();
            CreateMap<PrioridadeDTO[], IEnumerable<Prioridade>>();
            #endregion
            
            #region NotaAvaliacao
            CreateMap<NotaAvaliacao, NotaAvaliacaoDTO>();
            CreateMap<NotaAvaliacao[], IEnumerable<NotaAvaliacaoDTO>>();
            CreateMap<NotaAvaliacaoDTO, NotaAvaliacao>();
            CreateMap<NotaAvaliacaoDTO[], IEnumerable<NotaAvaliacao>>();
            #endregion
            
            #region Mensagem
            CreateMap<Mensagem, MensagemDTO>();
            CreateMap<Mensagem[], IEnumerable<MensagemDTO>>();
            CreateMap<MensagemDTO, Mensagem>();
            CreateMap<MensagemDTO[], IEnumerable<Mensagem>>();
            #endregion
            
            #region Departamento
            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<Departamento[], IEnumerable<DepartamentoDTO>>();
            CreateMap<DepartamentoDTO, Departamento>();
            CreateMap<DepartamentoDTO[], IEnumerable<Departamento>>();
            #endregion

            #region Chamado
            CreateMap<Chamado, ChamadoDTO>();
            CreateMap<Chamado[], IEnumerable<ChamadoDTO>>();
            CreateMap<ChamadoDTO, Chamado>();
            CreateMap<ChamadoDTO[], IEnumerable<Chamado>>();
            #endregion
            
            #region Assunto
            CreateMap<Assunto, AssuntoDTO>();
            CreateMap<Assunto[], IEnumerable<AssuntoDTO>>();
            CreateMap<AssuntoDTO, Assunto>();
            CreateMap<AssuntoDTO[], IEnumerable<Assunto>>();
            #endregion 
        }
    }
}
