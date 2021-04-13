using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;
using NetCoreAngular.Application.Interfaces.Services.Chamados;
using NetCoreAngular.Application.DTOs.Chamados;
using AutoMapper;

namespace NetCoreAngular.Application.Services.Chamados
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IMapper _mapper;
        private readonly IDepartamentoRepositorio _departamentoRepositorio;

        public DepartamentoService(IDepartamentoRepositorio departamentoRepositorio, IMapper mapper)
        {
            _departamentoRepositorio = departamentoRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartamentoDTO>> Consultar()
        {
            var departamentos = await _departamentoRepositorio.Consultar();

            return _mapper.Map<IEnumerable<DepartamentoDTO>>(departamentos);
        }
    }
}