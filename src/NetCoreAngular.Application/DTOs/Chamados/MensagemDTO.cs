using System;
using System.Collections.Generic;

namespace NetCoreAngular.Application.DTOs.Chamados
{
    public class MensagemDTO
    {
        public string Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ChamadoId { get; set; }
        public ChamadoDTO Chamado { get; set; }
        public string UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public IList<ArquivoChamadoDTO> ArquivosChamado { get; set; }
    }
}