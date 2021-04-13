using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs.Chamados;

namespace NetCoreAngular.Application.Interfaces.Services.Chamados
{
    public interface IChamadoService
    {
        Task<ChamadoDTO> Cadastrar(ChamadoDTO chamadoDto);
        Task Atualizar(string id, ChamadoDTO chamadoDto);
        Task<IEnumerable<ChamadoDTO>> Consultar();
        Task<ChamadoDTO> Consultar(string id);
    }
}