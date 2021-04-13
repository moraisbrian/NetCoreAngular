using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Application.DTOs;

namespace NetCoreAngular.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> AlterarSenha(string usuarioId, string senhaAntiga, string senhaNova);
        Task<IEnumerable<UsuarioDTO>> ObterUsuariosPorDepartamento(string departamentoId);
        Task<UsuarioDTO> Autenticar(string usuario, string senha);
    }
}