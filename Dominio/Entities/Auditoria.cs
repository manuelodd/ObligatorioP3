using Dominio.Enums;
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
            //throw new NotImplementedException();
        }
    }
}
