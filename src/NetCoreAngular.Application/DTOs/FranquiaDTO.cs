using System.Collections.Generic;

namespace NetCoreAngular.Application.DTOs
{
    public class FranquiaDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
        public IList<UsuarioDTO> Usuarios { get; set; }
    }
}