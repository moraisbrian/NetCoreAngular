using System.Collections.Generic;

namespace NetCoreAngular.Domain.Entidades.Chamados
{
    public class Prioridade : EntidadeBase
    {
        public string Identificacao { get; set; }
        public double TempoLimiteAtendimento { get; set; }
        public IList<Chamado> Chamados { get; set; }
    }
}