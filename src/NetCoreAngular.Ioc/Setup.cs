using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreAngular.Application.Interfaces.Services;
using NetCoreAngular.Application.Interfaces.Services.Chamados;
using NetCoreAngular.Application.Services;
using NetCoreAngular.Application.Services.Chamados;
using NetCoreAngular.Data;
using NetCoreAngular.Data.Repositorios;
using NetCoreAngular.Data.Repositorios.Chamados;
using NetCoreAngular.Application.Interfaces.Utils;
using NetCoreAngular.Domain.Interfaces.Repositorios;
using NetCoreAngular.Domain.Interfaces.Repositorios.Chamados;
using NetCoreAngular.Utils.GoogleDrive;
using NetCoreAngular.Utils.UploadPasta;
using NetCoreAngular.Application;

namespace NetCoreAngular.Ioc
{
    public class Setup
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(AutoMapperSetup));

            #region Repositorios
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IChamadoRepositorio), typeof(ChamadoRepositorio));
            services.AddScoped(typeof(IMensagemRepositorio), typeof(MensagemRepositorio));
            services.AddScoped(typeof(IAssuntoRepositorio), typeof(AssuntoRepositorio));
            services.AddScoped(typeof(IUsuarioRepositorio), typeof(UsuarioRepositorio));
            services.AddScoped(typeof(IDepartamentoRepositorio), typeof(DepartamentoRepositorio));
            services.AddScoped(typeof(INotaAvaliacaoRepositorio), typeof(NotaAvaliacaoRepositorio));
            services.AddScoped(typeof(IPrioridadeRepositorio), typeof(PrioridadeRepositorio));
            services.AddScoped(typeof(IProtocoloRepositorio), typeof(ProtocoloRepositorio));
            services.AddScoped(typeof(IFranquiaRepositorio), typeof(FranquiaRepositorio));
            #endregion

            #region Serviços
            services.AddScoped(typeof(IChamadoService), typeof(CadastroChamadoService));
            services.AddScoped(typeof(IMensagemService), typeof(CadastroMensagemService));
            services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
            services.AddScoped(typeof(IFranquiaService), typeof(FranquiaService));
            services.AddScoped(typeof(IAssuntoService), typeof(AssuntoService));
            services.AddScoped(typeof(IDepartamentoService), typeof(DepartamentoService));
            services.AddScoped(typeof(INotaAvaliacaoService), typeof(NotaAvaliacaoService));
            services.AddScoped(typeof(IPrioridadeService), typeof(PrioridadeService));
            #endregion

            #region Utils
            services.AddScoped(typeof(IGoogleDrive), typeof(GoogleDriveMethods));
            services.AddScoped(typeof(IArquivosPasta), typeof(ArquivosPasta));
            #endregion
        }
    }
}
