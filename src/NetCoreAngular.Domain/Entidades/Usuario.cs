using System.Collections.Generic;
using NetCoreAngular.Domain.Entidades.Chamados;

namespace NetCoreAngular.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public IList<Mensagem> Mensagens { get; set; }
        public IList<Franquia> Franquias { get; set; }
    }
}