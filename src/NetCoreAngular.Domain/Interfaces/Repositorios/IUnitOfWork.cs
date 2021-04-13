using System.Threading.Tasks;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;

namespace NetCoreAngular.Domain.Interfaces.Repositorios
{
    public interface IUnitOfWork
    {
        IChamadoRepositorio ChamadoRepositorio { get; }
        IMensagemRepositorio MensagemRepositorio { get; }
        IUsuarioRepositorio UsuarioRepositorio { get; }
        IAssuntoRepositorio AssuntoRepositorio { get; }
        IDepartamentoRepositorio DepartamentoRepositorio { get; }
        INotaAvaliacaoRepositorio NotaAvaliacaoRepositorio { get; }
        IPrioridadeRepositorio PrioridadeRepositorio { get; }
        IProtocoloRepositorio ProtocoloRepositorio { get; }
        IArquivoRepositorio ArquivoRepositorio { get; }
        IFranquiaRepositorio FranquiaRepositorio { get; }
        Task Commit();
    }
}