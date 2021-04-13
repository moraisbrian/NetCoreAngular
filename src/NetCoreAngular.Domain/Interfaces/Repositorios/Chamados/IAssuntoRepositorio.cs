using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Entidades.Chamados;

namespace NetCoreAngular.Domain.Interfaces.Repositorios.Chamados
{
    public interface IAssuntoRepositorio : IRepositorioBase<Assunto>
    {
        Task<IEnumerable<Assunto>> ObterAssuntosPorDepartamento(string departamentoId);
    }
}
