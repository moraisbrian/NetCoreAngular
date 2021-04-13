using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades;
using NetCoreAngular.Domain.Interfaces.Repositorios;

namespace NetCoreAngular.Data.Repositorios
{
    public class FranquiaRepositorio : IFranquiaRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public FranquiaRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Franquia> ConsultarPorId(string id)
        {
            return await _dbContext.Franquias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Franquia>> ConsultarPorUsuario(string usuarioId)
        {
            return await _dbContext.Usuarios
                .Where(x => x.Id == usuarioId)
                .SelectMany(x => x.Franquias)
                .ToListAsync();
        }
    }
}