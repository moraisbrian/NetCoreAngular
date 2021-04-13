using System.Collections.Generic;

namespace NetCoreAngular.Domain.Entidades.Chamados
{
    public class Assunto : EntidadeBase
    {
        public string Identificacao { get; set; }
        public IList<Chamado> Chamados { get; set; }
        public string DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}