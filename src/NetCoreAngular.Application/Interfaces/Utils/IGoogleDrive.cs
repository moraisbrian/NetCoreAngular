using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NetCoreAngular.Application.Interfaces.Utils
{
    public interface IGoogleDrive
    {
        Task<IEnumerable<Tuple<string, Stream>>> Download(string idPai = null);
        Task Upload(string nomeArquivo, Stream stream, string idPai = null);
    }
}