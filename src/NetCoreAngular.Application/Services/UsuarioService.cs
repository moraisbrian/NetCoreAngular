using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Interfaces.Repositorios;
using NetCoreAngular.Application.Interfaces.Services;
using NetCoreAngular.Application.DTOs;
using AutoMapper;

namespace NetCoreAngular.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        
        public UsuarioService(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<bool> AlterarSenha(string usuarioId, string senhaAntiga, string senhaNova)
        {
            var usuario = await _usuarioRepositorio.Consultar(usuarioId);

            if (usuario != null && usuario.Senha == senhaAntiga)
            {
                usuario.Senha = senhaNova;
                await _usuarioRepositorio.Commit();
                return true;
            }

            return false;
        }

        public async Task<UsuarioDTO> Autenticar(string usuario, string senha)
        {
            var user = await _usuarioRepositorio.ConsultarPorUsuarioSenha(usuario, senha);

            return _mapper.Map<UsuarioDTO>(user);
        }

        public async Task<IEnumerable<UsuarioDTO>> ObterUsuariosPorDepartamento(string departamentoId)
        {
            var usuarios = await _usuarioRepositorio.ConsultarUsuarioPorDepartamento(departamentoId);

            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }
    }
}