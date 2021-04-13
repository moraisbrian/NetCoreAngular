using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;
using NetCoreAngular.Application.Interfaces.Services.Chamados;
using NetCoreAngular.Application.DTOs.Chamados;
using AutoMapper;

namespace NetCoreAngular.Application.Services.Chamados
{
    public class PrioridadeService : IPrioridadeService
    {
        private readonly IMapper _mapper;
        private readonly IPrioridadeRepositorio _prioridadeRepositorio;

        public PrioridadeService(IPrioridadeRepositorio prioridadeRepositorio, IMapper mapper)
        {
            _prioridadeRepositorio = prioridadeRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrioridadeDTO>> Consultar()
        {
            var prioridades = await _prioridadeRepositorio.Consultar();

            return _mapper.Map<IEnumerable<PrioridadeDTO>>(prioridades);
        }
    }
}