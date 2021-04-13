using System.Security.Cryptography;
using System.Text;

namespace NetCoreAngular.Api.Config
{
    public class Criptografia
    {
        public static string GerarHash(string senha)
        {
            var valorCodificado = Encoding.UTF8.GetBytes(senha);
            var sha256 = SHA256.Create();
            var hashValue = sha256.ComputeHash(valorCodificado);
            var builder = new StringBuilder();

            foreach (var valor in hashValue)
            {
                builder.Append(valor.ToString("X2"));
            }

            return builder.ToString();
        }
    }
}