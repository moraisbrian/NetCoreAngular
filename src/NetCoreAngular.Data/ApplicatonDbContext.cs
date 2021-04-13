using Microsoft.EntityFrameworkCore;
using NetCoreAngular.Domain.Entidades.Chamados;
using NetCoreAngular.Data.Mapping.Chamados;
using NetCoreAngular.Domain.Entidades;
using NetCoreAngular.Data.Mapping;

namespace NetCoreAngular.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<NotaAvaliacao> NotasAvaliacao { get; set; }
        public DbSet<Prioridade> Prioridades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Protocolo> Protocolo { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Franquia> Franquias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssuntoMap());
            modelBuilder.ApplyConfiguration(new ChamadoMap());
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
            modelBuilder.ApplyConfiguration(new MensagemMap());
            modelBuilder.ApplyConfiguration(new NotaAvaliacaoMap());
            modelBuilder.ApplyConfiguration(new PrioridadeMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProtocoloMap());
            modelBuilder.ApplyConfiguration(new ArquivoMap());
            modelBuilder.ApplyConfiguration(new FranquiaMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
