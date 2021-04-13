using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Entidades;

namespace NetCoreAngular.Domain.Interfaces.Repositorios
{
    public interface IArquivoRepositorio
    {
        Task<IEnumerable<Arquivo>> Consultar(string idPai = null);
        Task Adicionar(Arquivo arquivo);
        Task Commit();
    }
}