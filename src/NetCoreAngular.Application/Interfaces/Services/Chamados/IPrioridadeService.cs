using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs.Chamados;

namespace NetCoreAngular.Application.Interfaces.Services.Chamados
{
    public interface IPrioridadeService
    {
        Task<IEnumerable<PrioridadeDTO>> Consultar();
    }
}