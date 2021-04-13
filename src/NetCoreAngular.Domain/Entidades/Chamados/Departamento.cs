using System.Collections.Generic;

namespace NetCoreAngular.Domain.Entidades.Chamados
{
    public class Departamento : EntidadeBase
    {
        public string Identificacao { get; set; }
        public IList<Usuario> Usuarios { get; set; }
        public IList<Assunto> Assuntos { get; set; }
        public IList<Chamado> Chamados { get; set; }
    }
}