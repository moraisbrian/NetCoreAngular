using System;

namespace NetCoreAngular.Domain.Entidades.Chamados
{
    public class Mensagem : EntidadeBase
    {
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ChamadoId { get; set; }
        public Chamado Chamado { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}