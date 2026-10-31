using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Historias
{
    public class ObtenerHistoriaPorIdCU : IObtenerHistoriaPorId
    {
        private IRepositorioHistorias repositorio;
        public ObtenerHistoriaPorIdCU(IRepositorioHistorias repo)
        {
            repositorio = repo;
        }

        public HistoriaDTO Execute(int id)
        {
            return HistoriaDTOMapper.ToDTO(repositorio.FindById(id));
        }
    }
}
