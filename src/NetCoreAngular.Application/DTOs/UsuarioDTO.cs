using NetCoreAngular.Application.DTOs.Chamados;

namespace NetCoreAngular.Application.DTOs
{
    public class UsuarioDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string DepartamentoId { get; set; }
        public DepartamentoDTO Departamento { get; set; }
    }
}