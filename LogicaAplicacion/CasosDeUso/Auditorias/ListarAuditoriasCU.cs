using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Auditorias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Auditorias
{
    public class ListarAuditoriasCU : IListarAuditorias
    {
        private IRepositorioAuditorias repositorio;

        public ListarAuditoriasCU(IRepositorioAuditorias repo)
        {
            repositorio = repo;
        }

        public List<AuditoriaDTO> Execute(int? historiaId, int? administradorId)
        {
            List<Auditoria> auditorias = repositorio.FindByFiltros(historiaId, administradorId);

            List<AuditoriaDTO> dtos = new List<AuditoriaDTO>();

            foreach (Auditoria auditoria in auditorias)
            {
                dtos.Add(new AuditoriaDTO
                {
                    Id = auditoria.Id,
                    Accion = auditoria.Accion,
                    Fecha = auditoria.Fecha,
                    AdministradorId = auditoria.AdministradorId,
                    HistoriaId = auditoria.HistoriaId
                });
            }

            return dtos;
        }
    }
}
