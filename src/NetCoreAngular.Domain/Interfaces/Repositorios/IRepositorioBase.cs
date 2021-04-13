using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Entidades;

namespace NetCoreAngular.Domain.Interfaces.Repositorios
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        Task Adicionar(T entidade);
        Task<T> Consultar(string id);
        Task<IEnumerable<T>> Consultar();
        Task Commit();
    }
}