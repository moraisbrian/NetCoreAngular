using NetCoreAngular.Data.Repositorios;
using NetCoreAngular.Data.Repositorios.Chamados;
using NetCoreAngular.Domain.Interfaces.Repositorios;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;
using System.Threading.Tasks;

namespace NetCoreAngular.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public ChamadoRepositorio chamadoRepositorio;
        public MensagemRepositorio mensagemRepositorio;
        public UsuarioRepositorio usuarioRepositorio;
        public AssuntoRepositorio assuntoRepositorio;
        public DepartamentoRepositorio departamentoRepositorio;
        public NotaAvaliacaoRepositorio notaAvaliacaoRepositorio;
        public PrioridadeRepositorio prioridadeRepositorio;
        public ProtocoloRepositorio protocoloRepositorio;
        public ArquivoRepositorio arquivoRepositorio;
        public FranquiaRepositorio franquiaRepositorio;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IChamadoRepositorio ChamadoRepositorio
        {
            get
            {
                if (chamadoRepositorio == null)
                    chamadoRepositorio = new ChamadoRepositorio(_dbContext);
                return chamadoRepositorio;
            }
        }

        public IMensagemRepositorio MensagemRepositorio
        {
            get
            {
                if (mensagemRepositorio == null)
                    mensagemRepositorio = new MensagemRepositorio(_dbContext);
                return mensagemRepositorio;
            }
        }

        public IUsuarioRepositorio UsuarioRepositorio
        {
            get
            {
                if (usuarioRepositorio == null)
                    usuarioRepositorio = new UsuarioRepositorio(_dbContext);
                return usuarioRepositorio;
            }
        }

        public IAssuntoRepositorio AssuntoRepositorio
        {
            get
            {
                if (assuntoRepositorio == null)
                    assuntoRepositorio = new AssuntoRepositorio(_dbContext);
                return assuntoRepositorio;
            }
        }

        public IDepartamentoRepositorio DepartamentoRepositorio
        {
            get
            {
                if (departamentoRepositorio == null)
                    departamentoRepositorio = new DepartamentoRepositorio(_dbContext);
                return departamentoRepositorio;
            }
        }

        public INotaAvaliacaoRepositorio NotaAvaliacaoRepositorio
        {
            get
            {
                if (notaAvaliacaoRepositorio == null)
                    notaAvaliacaoRepositorio = new NotaAvaliacaoRepositorio(_dbContext);
                return notaAvaliacaoRepositorio;
            }
        }

        public IPrioridadeRepositorio PrioridadeRepositorio
        {
            get
            {
                if (prioridadeRepositorio == null)
                    prioridadeRepositorio = new PrioridadeRepositorio(_dbContext);
                return prioridadeRepositorio;
            }
        }

        public IProtocoloRepositorio ProtocoloRepositorio
        {
            get 
            {
                if (protocoloRepositorio == null)
                    protocoloRepositorio = new ProtocoloRepositorio(_dbContext);
                return protocoloRepositorio;
            }
        }

        public IArquivoRepositorio ArquivoRepositorio
        {
            get
            {
                if (arquivoRepositorio == null)
                    arquivoRepositorio = new ArquivoRepositorio(_dbContext);
                return arquivoRepositorio;
            }
        }

        public IFranquiaRepositorio FranquiaRepositorio
        {
            get
            {
                if (franquiaRepositorio == null)
                    franquiaRepositorio = new FranquiaRepositorio(_dbContext);
                return franquiaRepositorio;
            }
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
