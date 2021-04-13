using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades.Chamados;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;

namespace NetCoreAngular.Data.Repositorios.Chamados
{
    public class NotaAvaliacaoRepositorio : INotaAvaliacaoRepositorio
    {
        private readonly ApplicationDbContext _dbContext;
        public NotaAvaliacaoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Adicionar(NotaAvaliacao nota)
        {
            await _dbContext.NotasAvaliacao.AddAsync(nota);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<NotaAvaliacao> Consultar(string id)
        {
            return await _dbContext.NotasAvaliacao.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<NotaAvaliacao>> Consultar()
        {
            return await _dbContext.NotasAvaliacao.ToListAsync();
        }
    }
}