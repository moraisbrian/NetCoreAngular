using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs.Chamados;

namespace NetCoreAngular.Application.Interfaces.Services.Arquivos
{
    public interface IArquivosBancoService
    {
        Task<IEnumerable<ArquivoChamadoDTO>> ObterArquivosBanco(string mensagemId);
        Task SalvarArquivosBanco(string mensagemId, List<ArquivoChamadoDTO> arquivos);
    }
}