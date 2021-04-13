using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs;

namespace NetCoreAngular.Application.Interfaces.Services
{
    public interface IFranquiaService
    {
        Task<IEnumerable<FranquiaDTO>> ConsultarPorUsuario(string usuarioId);
    }
}