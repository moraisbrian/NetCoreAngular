using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades;
using NetCoreAngular.Domain.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public UsuarioRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Usuario> Consultar(string id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Usuario>> Consultar()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ConsultarPorUsuarioSenha(string usuario, string senha)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Nome == usuario && x.Senha == senha);
        }

        public async Task<IEnumerable<Usuario>> ConsultarUsuarioPorDepartamento(string departamentoId)
        {
            return await _dbContext.Usuarios.Where(x => x.DepartamentoId == departamentoId).ToListAsync();
        }
    }
}
