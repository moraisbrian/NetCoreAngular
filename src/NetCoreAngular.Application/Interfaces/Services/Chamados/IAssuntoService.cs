using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs.Chamados;

namespace NetCoreAngular.Application.Interfaces.Services.Chamados
{
    public interface IAssuntoService
    {
        Task<IEnumerable<AssuntoDTO>> Consultar();
        Task<IEnumerable<AssuntoDTO>> ObterAssuntosPorDepartamento(string departamentoId);
    }
}