using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;
using NetCoreAngular.Application.Interfaces.Services.Chamados;
using NetCoreAngular.Application.DTOs.Chamados;
using AutoMapper;

namespace NetCoreAngular.Application.Services.Chamados
{
    public class AssuntoService : IAssuntoService
    {
        private readonly IMapper _mapper;
        private readonly IAssuntoRepositorio _assuntoRepositorio;
        public AssuntoService(IAssuntoRepositorio assuntoRepositorio, IMapper mapper)
        {
            _assuntoRepositorio = assuntoRepositorio; 
            _mapper = mapper;   
        }

        public async Task<IEnumerable<AssuntoDTO>> Consultar()
        {
            var assuntos = await _assuntoRepositorio.Consultar();

            return _mapper.Map<IEnumerable<AssuntoDTO>>(assuntos);
        }

        public async Task<IEnumerable<AssuntoDTO>> ObterAssuntosPorDepartamento(string departamentoId)
        {
            var assuntos = await _assuntoRepositorio.ObterAssuntosPorDepartamento(departamentoId);

            return _mapper.Map<IEnumerable<AssuntoDTO>>(assuntos);
        }
    }
}