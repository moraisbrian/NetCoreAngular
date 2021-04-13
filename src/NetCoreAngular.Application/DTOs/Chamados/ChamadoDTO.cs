using System;
using System.Collections.Generic;
using NetCoreAngular.Domain.Enums.Chamados;

namespace NetCoreAngular.Application.DTOs.Chamados
{
    public class ChamadoDTO
    {
        
        public ChamadoDTO()
        {
            Mensagens = new List<MensagemDTO>();
        }

        public string Id { get; set; }
        public string Protocolo { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataUltimaInteracao { get; set; }
        public string Empresa { get; set; }
        public Situacao Situacao { get; set; }
        public Status Status { get; set; }
        public string ObservacoesEncerramento { get; set; }
        public string AssuntoId { get; set; }
        public AssuntoDTO Assunto { get; set; }
        public IList<MensagemDTO> Mensagens { get; set; }
        public string NotaAvaliacaoId { get; set; }
        public NotaAvaliacaoDTO NotaAvaliacao { get; set; }
        public string DepartamentoId { get; set; }
        public DepartamentoDTO Departamento { get; set; }
        public string PrioridadeId { get; set; }
        public PrioridadeDTO Prioridade { get; set; }
        public string ClienteId { get; set; }
        public UsuarioDTO Cliente { get; set; }
        public string AtendenteId { get; set; }
        public UsuarioDTO Atendente { get; set; }
        public string FranquiaId { get; set; }
        public FranquiaDTO Franquia { get; set; }
        public string MensagemInicial { get; set; }
    }
}