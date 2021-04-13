using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades;
using NetCoreAngular.Domain.Interfaces.Repositorios;

namespace NetCoreAngular.Data.Repositorios
{
    public class ArquivoRepositorio : IArquivoRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public ArquivoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(Arquivo arquivo)
        {
            await _dbContext.Arquivos.AddAsync(arquivo);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Arquivo>> Consultar(string idPai = null)
        {
            if (idPai != null)
                return await _dbContext.Arquivos.Where(x => x.IdPai == idPai).ToListAsync();
            else
                return await _dbContext.Arquivos.ToListAsync();
        }
    }
}