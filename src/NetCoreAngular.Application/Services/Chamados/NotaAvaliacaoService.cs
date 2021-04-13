using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;
using NetCoreAngular.Application.Interfaces.Services.Chamados;
using NetCoreAngular.Application.DTOs.Chamados;
using AutoMapper;

namespace NetCoreAngular.Application.Services.Chamados
{
    public class NotaAvaliacaoService : INotaAvaliacaoService
    {
        private readonly IMapper _mapper;
        private readonly INotaAvaliacaoRepositorio _notaAvaliacaoRepositorio;

        public NotaAvaliacaoService(INotaAvaliacaoRepositorio notaAvaliacaoRepositorio, IMapper mapper)
        {
            _notaAvaliacaoRepositorio = notaAvaliacaoRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotaAvaliacaoDTO>> Consultar()
        {
            var notas = await _notaAvaliacaoRepositorio.Consultar();

            return _mapper.Map<IEnumerable<NotaAvaliacaoDTO>>(notas);
        }
    }
}