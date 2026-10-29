using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Historias
{
    public class ListarHistoriasCU : IListarHistorias
    {
        private IRepositorioHistorias repositorio;
        public ListarHistoriasCU(IRepositorioHistorias repo)
        {
            this.repositorio = repo;
        }

        public List<HistoriaDTO> Execute()
        {
            List<HistoriaDTO> listado = new List<HistoriaDTO>();
            foreach(Historia historia in repositorio.FindAll())
            {
                listado.Add(HistoriaDTOMapper.ToDTO(historia));
            }

            return listado;
        }
    }
}
