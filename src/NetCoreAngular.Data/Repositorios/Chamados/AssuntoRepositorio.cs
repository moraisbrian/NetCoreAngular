using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades.Chamados;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Repositorios.Chamados
{
    public class AssuntoRepositorio : IAssuntoRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public AssuntoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(Assunto assunto)
        {
            await _dbContext.Assuntos.AddAsync(assunto);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Assunto> Consultar(string id)
        {
            return await _dbContext.Assuntos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Assunto>> Consultar()
        {
            return await _dbContext.Assuntos
                .Include(x => x.Departamento)
                .ToListAsync();
        }

        public async Task<IEnumerable<Assunto>> ObterAssuntosPorDepartamento(string departamentoId)
        {
            return await _dbContext.Assuntos.Where(x => x.DepartamentoId == departamentoId).ToListAsync();
        }
    }
}
