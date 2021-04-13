using System.Collections.Generic;

namespace NetCoreAngular.Domain.Entidades
{
    public class Franquia : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
        public IList<Usuario> Usuarios { get; set; }
    }
}