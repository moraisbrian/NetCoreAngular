using System;
using System.Collections.Generic;
using System.IO;
using Google.Apis.Drive.v3;
using MimeTypes;
using System.Linq;
using System.Threading.Tasks;
using NetCoreAngular.Application.Interfaces.Utils;

namespace NetCoreAngular.Utils.GoogleDrive
{
    public class GoogleDriveMethods : IGoogleDrive
    {
        private static readonly DriveService _servico = Auth.AbrirServico();

        private static readonly string _driveId = "0ALcc1kcWM9oxUk9PVA";

        public async Task<IEnumerable<Tuple<string, Stream>>> Download(string idPai = null)
        {
            var request = _servico.Files.List();
            request.SupportsAllDrives = true;
            request.IncludeItemsFromAllDrives = true;
            request.Corpora = "drive";
            request.DriveId = _driveId;
            request.Fields = "files(id, name, size, description, originalFilename, driveId)";
            request.Q = "trashed = false";
            
            if (idPai != null)
                request.Q += $" and fullText contains '{idPai}'";
            
            var resultado = await request.ExecuteAsync();
            
            var files = resultado.Files;
            var streams = new List<Tuple<string, Stream>>();
            
            foreach (var file in files)
            {
                var download = _servico.Files.Get(file.Id);
                download.SupportsAllDrives = true;
                
                var stream = new MemoryStream();
                await download.DownloadAsync(stream);
                streams.Add(new Tuple<string, Stream>(file.OriginalFilename, stream));
            }

            return streams;
        }
        
        public async Task Upload(string nomeArquivo, Stream stream, string idPai = null)
        {
            var arquivo = new Google.Apis.Drive.v3.Data.File();
            arquivo.Name = Guid.NewGuid().ToString() + Path.GetExtension(nomeArquivo);
            arquivo.DriveId = _driveId;
            arquivo.OriginalFilename = nomeArquivo;
            arquivo.MimeType = MimeTypeMap.GetMimeType(Path.GetExtension(nomeArquivo));
            
            var diretorioDiario =  await CriarDiretorio();

            arquivo.Parents = new List<string> { diretorioDiario };
            
            if (idPai != null)
                arquivo.Description = idPai;

            var request = _servico.Files.Create(arquivo, stream, arquivo.MimeType);
            request.SupportsAllDrives = true;

            await request.UploadAsync();
        }
        
        private async Task<string> CriarDiretorio()
        {
            var mes = DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
            var dia = DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            var nomeDiretorio = $"{DateTime.Now.Year}{mes}{dia}";
            var diretorioCriado = await ObterArquivoId(nomeDiretorio);
            
            if (diretorioCriado.Length == 0)
            {
                var diretorio = new Google.Apis.Drive.v3.Data.File();
                diretorio.DriveId = _driveId;
                diretorio.Name = nomeDiretorio;
                diretorio.Parents = new List<string> { _driveId };
                diretorio.MimeType = "application/vnd.google-apps.folder";

                var request = _servico.Files.Create(diretorio);
                request.SupportsAllDrives = true;
                await request.ExecuteAsync();

                diretorioCriado = await ObterArquivoId(nomeDiretorio);
            }

            return diretorioCriado.FirstOrDefault();
        }

        private async Task<string[]> ObterArquivoId(string nome)
        {
            var ids = new List<string>();
            var request = _servico.Files.List();
            request.SupportsAllDrives = true;
            request.IncludeItemsFromAllDrives = true;
            request.Corpora = "drive";
            request.DriveId = _driveId;
            request.Q = $"name = '{nome}' and trashed = false";
            request.Fields = "files(id, driveId)";
            var resultado = await request.ExecuteAsync();
            var arquivos = resultado.Files;

            if (arquivos != null && arquivos.Any())
            {
                foreach (var arquivo in arquivos)
                {
                    ids.Add(arquivo.Id);
                }
            }

            return ids.ToArray();
        }
    }
}