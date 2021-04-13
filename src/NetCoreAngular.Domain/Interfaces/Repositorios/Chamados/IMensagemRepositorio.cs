using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Entidades.Chamados;

namespace NetCoreAngular.Domain.Interfaces.Repositorios.Chamados
{
    public interface IMensagemRepositorio : IRepositorioBase<Mensagem>
    {
        Task<IEnumerable<Mensagem>> ConsultarPorChamado(string chamadoId);
    }
}