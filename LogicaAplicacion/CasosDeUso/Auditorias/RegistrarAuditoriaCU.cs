using Dominio.Entities;
using Dominio.Enums;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso.Auditorias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Auditorias
{
    public class RegistrarAuditoriaCU : IRegistrarAuditoria
    {
        private IRepositorioAuditorias repositorio;
        public RegistrarAuditoriaCU(IRepositorioAuditorias repo)
        {
            repositorio = repo;
        }

        public void Execute(int historiaId, int adminId, AccionAuditoria accion)
        {
            Auditoria audi = new Auditoria
            {
                HistoriaId = historiaId,
                AdministradorId = adminId,
                Accion = accion,
                Fecha = DateTime.Now
            };

            repositorio.Add(audi);
        }
    }
}
