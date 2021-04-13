using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs.Chamados;

namespace NetCoreAngular.Application.Interfaces.Services.Arquivos
{
    public interface IArquivosPastaService
    {
        IEnumerable<ArquivoChamadoDTO> ObterArquivosPasta(string mensagemId);

        Task SalvarArquivosPasta(string mensagemId, List<ArquivoChamadoDTO> arquivos);
    }
}