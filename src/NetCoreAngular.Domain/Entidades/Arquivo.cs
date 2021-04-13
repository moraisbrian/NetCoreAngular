namespace NetCoreAngular.Domain.Entidades
{
    public class Arquivo : EntidadeBase
    {
        public string Nome { get; set; }
        public byte[] Conteudo { get; set; }
        public string IdPai { get; set; }
    }
}