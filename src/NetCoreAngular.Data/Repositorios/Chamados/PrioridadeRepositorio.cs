using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades.Chamados;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;

namespace NetCoreAngular.Data.Repositorios.Chamados
{
    public class PrioridadeRepositorio : IPrioridadeRepositorio
    {
        private readonly ApplicationDbContext _dbContext;
        public PrioridadeRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(Prioridade prioridade)
        {
            await _dbContext.AddAsync(prioridade);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Prioridade> Consultar(string id)
        {
            return await _dbContext.Prioridades.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Prioridade>> Consultar()
        {
            return await _dbContext.Prioridades.ToListAsync();
        }
    }
}