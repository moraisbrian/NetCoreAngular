using System.Threading.Tasks;
using NetCoreAngular.Domain.Entidades.Chamados;

namespace NetCoreAngular.Domain.Interfaces.Repositorios.Chamados
{
    public interface IProtocoloRepositorio
    {
        Task<Protocolo> Consultar();
        Task Salvar(Protocolo protocolo);
        Task Commit();
    }
}