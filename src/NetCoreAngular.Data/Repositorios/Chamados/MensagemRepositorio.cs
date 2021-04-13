using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades.Chamados;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Repositorios.Chamados
{
    public class MensagemRepositorio : IMensagemRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public MensagemRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(Mensagem mensagem)
        {
            await _dbContext.Mensagens.AddAsync(mensagem);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Mensagem>> ConsultarPorChamado(string chamadoId)
        {
            return await _dbContext.Mensagens
                .Include(x => x.Usuario)
                .Where(x => x.ChamadoId == chamadoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Mensagem>> Consultar()
        {
            return await _dbContext.Mensagens.ToListAsync();
        }

        public async Task<Mensagem> Consultar(string id)
        {
            return await _dbContext.Mensagens.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
