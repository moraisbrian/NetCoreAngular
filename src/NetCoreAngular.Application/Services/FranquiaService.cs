using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Interfaces.Repositorios;
using NetCoreAngular.Application.Interfaces.Services;
using NetCoreAngular.Application.DTOs;
using AutoMapper;

namespace NetCoreAngular.Application.Services
{
    public class FranquiaService : IFranquiaService
    {
        private readonly IMapper _mapper;
        private readonly IFranquiaRepositorio _franquiaRepositorio;
        public FranquiaService(IFranquiaRepositorio franquiaRepositorio, IMapper mapper)
        {
            _franquiaRepositorio = franquiaRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FranquiaDTO>> ConsultarPorUsuario(string usuarioId)
        {
            var franquias = await _franquiaRepositorio.ConsultarPorUsuario(usuarioId);

            return _mapper.Map<IEnumerable<FranquiaDTO>>(franquias);
        }
    }
}