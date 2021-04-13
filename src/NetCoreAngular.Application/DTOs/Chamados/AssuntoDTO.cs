using System.Collections.Generic;

namespace NetCoreAngular.Application.DTOs.Chamados
{
    public class AssuntoDTO
    {
        public string Id { get; set; }
        public string Identificacao { get; set; }
        public IList<ChamadoDTO> Chamados { get; set; }
        public string DepartamentoId { get; set; }
        public DepartamentoDTO Departamento { get; set; }
    }
}