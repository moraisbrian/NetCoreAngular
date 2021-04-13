using System;
using System.Collections.Generic;
using NetCoreAngular.Domain.Enums.Chamados;

namespace NetCoreAngular.Domain.Entidades.Chamados
{
    public class Chamado : EntidadeBase
    {
        public Chamado()
        {
            Mensagens = new List<Mensagem>();
        }

        public string Protocolo { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataUltimaInteracao { get; set; }
        public string Empresa { get; set; }
        public Situacao Situacao { get; set; }
        public Status Status { get; set; }
        public string ObservacoesEncerramento { get; set; }
        public string AssuntoId { get; set; }
        public Assunto Assunto { get; set; }
        public IList<Mensagem> Mensagens { get; set; }
        public string NotaAvaliacaoId { get; set; }
        public NotaAvaliacao NotaAvaliacao { get; set; }
        public string DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public string PrioridadeId { get; set; }
        public Prioridade Prioridade { get; set; }
        public string ClienteId { get; set; }
        public Usuario Cliente { get; set; }
        public string AtendenteId { get; set; }
        public Usuario Atendente { get; set; }
        public string FranquiaId { get; set; }
        public Franquia Franquia { get; set; }
    }
}