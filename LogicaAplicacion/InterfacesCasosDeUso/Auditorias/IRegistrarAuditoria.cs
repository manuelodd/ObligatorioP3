using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Auditorias
{
    public interface IRegistrarAuditoria
    {
        public void Execute(int historiaId, int adminId, AccionAuditoria accion);
    }
}
