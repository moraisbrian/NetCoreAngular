using System.IO;

namespace NetCoreAngular.Application.DTOs.Chamados
{
    public class ArquivoChamadoDTO
    {
        public string Id { get; set; }
        public string MensagemId { get; set; }
        public Stream ConteudoStream { get; set; }
        public byte[] ConteudoByte { get; set; }
        public string Nome { get; set; }
        public int Tamanho { get; set; }
    }
}