using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades.Chamados;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;

namespace NetCoreAngular.Data.Repositorios.Chamados
{
    public class ProtocoloRepositorio : IProtocoloRepositorio
    {
        private readonly ApplicationDbContext _dbContext;
        public ProtocoloRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Protocolo> Consultar()
        {
            return await _dbContext.Protocolo.OrderBy(x => x.Numero).FirstOrDefaultAsync();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Salvar(Protocolo protocolo)
        {
            await _dbContext.Protocolo.AddAsync(protocolo);
        }
    }
}