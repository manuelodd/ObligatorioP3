using Dominio.Enums;
using Dominio.Exceptions;
using Dominio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Auditoria : IValidable
    {
        public int Id { get; set; }
        public AccionAuditoria Accion { get; set; }
        public DateTime Fecha { get; set; }
        public int AdministradorId { get; set; }
        public int HistoriaId { get; set; }

        public void Validar()
        {
            if (Fecha == default)       throw new AuditoriaException("La fecha de auditoría es obligatoria.");
            if (AdministradorId <= 0)   throw new AuditoriaException("El administrador es inválido.");
            if (HistoriaId <= 0)        throw new AuditoriaException("La historia es inválida.");
        }
    }
}
