using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace NetCoreAngular.Utils.GoogleDrive
{
    public class Auth
    {
        private static readonly string _caminhoTemporarioCredentials = Path.GetTempPath() + "credentials.json";

        private static readonly string _credentials = @"";

        private static Stream ObterCredentialStream()
        {
            var sw = new StreamWriter(_caminhoTemporarioCredentials);
            sw.Write(_credentials);
            sw.Close();
            return File.Open(_caminhoTemporarioCredentials, FileMode.Open);
        }

        private static UserCredential Autenticar()
        {
            UserCredential credential;

            var diretorioAtual = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var diretorioCredenciais = Path.Combine(diretorioAtual, "credential");
            
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(ObterCredentialStream()).Secrets,
                new[] { DriveService.Scope.Drive },
                "user",
                CancellationToken.None,
                new FileDataStore(diretorioCredenciais, true)
            )
            .Result;

            File.Delete(_caminhoTemporarioCredentials);

            return credential;
        }

        public static DriveService AbrirServico()
        {
            var credential = Autenticar();

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });
        }
    }
}