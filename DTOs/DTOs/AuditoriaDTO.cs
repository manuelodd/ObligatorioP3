using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class AuditoriaDTO
    {
        public int Id { get; set; }
        public AccionAuditoria Accion { get; set; }
        public DateTime Fecha { get; set; }
        public int AdministradorId { get; set; }
        public int HistoriaId { get; set; }
    }
}
