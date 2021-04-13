using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Entidades;

namespace NetCoreAngular.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Task<IEnumerable<Usuario>> ConsultarUsuarioPorDepartamento(string departamentoId);
        Task<Usuario> ConsultarPorUsuarioSenha(string usuario, string senha);
    }
}
