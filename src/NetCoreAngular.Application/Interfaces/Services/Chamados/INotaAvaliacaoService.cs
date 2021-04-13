using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs.Chamados;

namespace NetCoreAngular.Application.Interfaces.Services.Chamados
{
    public interface INotaAvaliacaoService
    {
        Task<IEnumerable<NotaAvaliacaoDTO>> Consultar();
    }
}