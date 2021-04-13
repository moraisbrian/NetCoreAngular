using System;
using System.Collections.Generic;
using System.IO;

namespace NetCoreAngular.Application.Interfaces.Utils
{
    public interface IArquivosPasta
    {
        IEnumerable<Tuple<string, Stream>> ObterArquivos(string idPai);
        void SalvarArquivo(string nome, string idPai, byte[] arquivo);
    }
}