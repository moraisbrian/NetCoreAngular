using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs.Chamados;
using NetCoreAngular.Application.Interfaces.Services.Arquivos;

namespace NetCoreAngular.Application.Interfaces.Services.Chamados
{
    public interface IMensagemService : IArquivosBancoService, IArquivosGoogleDriveService, IArquivosPastaService
    {
        Task<string> Cadastrar(MensagemDTO mensagemDto);
        Task<IEnumerable<MensagemDTO>> ConsultarPorChamado(string id);
    }
}