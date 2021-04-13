using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades.Chamados;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Repositorios.Chamados
{
    public class ChamadoRepositorio : IChamadoRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public ChamadoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(Chamado chamado)
        {
            await _dbContext.Chamados.AddAsync(chamado);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Chamado> Consultar(string id)
        {
            return await _dbContext.Chamados
                .Include(x => x.Assunto)
                .Include(x => x.Prioridade)
                .Include(x => x.Cliente)
                .Include(x => x.Atendente)
                .Include(x => x.Departamento)
                .Include(x => x.Franquia)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Chamado>> Consultar()
        {
            return await _dbContext.Chamados
                .Include(x => x.Assunto)
                .Include(x => x.Prioridade)
                .Include(x => x.Cliente)
                .Include(x => x.Atendente)
                .Include(x => x.Departamento)
                .ToListAsync();
        }
    }
}
