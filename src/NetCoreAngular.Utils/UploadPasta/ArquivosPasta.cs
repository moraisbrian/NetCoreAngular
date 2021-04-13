using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using NetCoreAngular.Application.Interfaces.Utils;

namespace NetCoreAngular.Utils.UploadPasta
{
    public class ArquivosPasta : IArquivosPasta
    {
        private readonly string _caminho;

        public ArquivosPasta(IConfiguration config)
        {
            _caminho = config["FileSettings:DirectoryFilePath"];
        }

        private void VerificarCaminho()
        {
            if (string.IsNullOrEmpty(_caminho))
            {
                throw new ArgumentNullException("Caminho para salvar arquivos não especificado no arquivo de configurações");
            }
            else if (!Directory.Exists(_caminho))
            {
                try 
                {
                    Directory.CreateDirectory(_caminho);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
                
            }
        }

        private string CriarPastaDiaria()
        {
            VerificarCaminho();

            var dia = DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            var mes = DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();

            var nomePasta = $"{DateTime.Now.Year}{mes}{dia}";

            if (!Directory.Exists(_caminho + nomePasta))
            {
                Directory.CreateDirectory(_caminho + nomePasta);
            }

            return _caminho + nomePasta + "\\";
        }

        private string GerarNomeArquivo(string nome, string idPai)
        {
            var extensao = Path.GetExtension(nome);
            nome = nome.Replace("_", "").Replace(extensao, "");
            nome = $"{nome}_{idPai}{extensao}";
            return nome;
        }

        public void SalvarArquivo(string nome, string idPai, byte[] arquivo)
        {
            var nomeComId = GerarNomeArquivo(nome, idPai);
            var caminho = CriarPastaDiaria() + nomeComId;

            using (var fs = new FileStream(caminho, FileMode.Create, FileAccess.Write))
            {
                fs.Write(arquivo, 0, arquivo.Length);
            }
        }

        public IEnumerable<Tuple<string, Stream>> ObterArquivos(string idPai)
        {
            VerificarCaminho();

            var files = new List<Tuple<string, Stream>>();
            var diretorios = Directory.GetDirectories(_caminho);

            foreach (var diretorio in diretorios)
            {
                var arquivos = Directory.GetFiles(diretorio);

                foreach (var arquivo in arquivos)
                {
                    var extensao = Path.GetExtension(arquivo);
                    var split = arquivo.Replace(extensao, "").Split('_');
                    
                    if (split.Length == 2)
                    {
                        var nome = Path.GetFileName(split[0]);
                        var id = split[1];

                        if (id == idPai)
                        {
                            var fs = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
                            files.Add(new Tuple<string, Stream>(nome + extensao, fs));
                        }
                    }
                }
            }

            return files;
        }
    }
}