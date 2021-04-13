using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades.Chamados;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;

namespace NetCoreAngular.Data.Repositorios.Chamados
{
    public class DepartamentoRepositorio : IDepartamentoRepositorio
    {
        private readonly ApplicationDbContext _dbContext;
        
        public DepartamentoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(Departamento departamento)
        {
            await _dbContext.Departamentos.AddAsync(departamento);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Departamento> Consultar(string id)
        {
            return await _dbContext.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Departamento>> Consultar()
        {
            return await _dbContext.Departamentos.ToListAsync();
        }
    }
}