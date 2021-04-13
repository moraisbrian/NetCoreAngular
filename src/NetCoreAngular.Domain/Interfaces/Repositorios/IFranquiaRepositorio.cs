using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Entidades;

namespace NetCoreAngular.Domain.Interfaces.Repositorios
{
    public interface IFranquiaRepositorio
    {
        Task<IEnumerable<Franquia>> ConsultarPorUsuario(string usuarioId);
        Task<Franquia> ConsultarPorId(string id);
    }
}