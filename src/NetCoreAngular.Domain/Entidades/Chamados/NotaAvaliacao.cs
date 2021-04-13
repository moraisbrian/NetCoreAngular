using System.Collections.Generic;

namespace NetCoreAngular.Domain.Entidades.Chamados
{
    public class NotaAvaliacao : EntidadeBase
    {
        public string Identificacao { get; set; }
        public IList<Chamado> Chamados { get; set; }
    }
}