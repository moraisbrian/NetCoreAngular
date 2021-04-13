using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs.Chamados;

namespace NetCoreAngular.Application.Interfaces.Services.Arquivos
{
    public interface IArquivosGoogleDriveService
    {
        Task<IEnumerable<ArquivoChamadoDTO>> ObterArquivosGoogleDrive(string mensagemId);
        Task SalvarArquivosGoogleDrive(string mensagemId, List<ArquivoChamadoDTO> arquivos);
    }
}