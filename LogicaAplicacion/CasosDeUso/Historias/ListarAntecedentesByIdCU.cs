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
    public class ListarAntecedentesByIdCU : IListarAntecedentesById
    {
        private IRepositorioHistorias repositorio;
        private IRepositorioCapitulos repositorioC;

        public ListarAntecedentesByIdCU(IRepositorioHistorias repo, IRepositorioCapitulos repoC)
        {
            this.repositorio = repo;
            this.repositorioC = repoC;
        }

        public List<CapitulosToListDTO> Execute(int id)
        {
            List<CapitulosToListDTO> listado = new List<CapitulosToListDTO>();
            foreach (Intermedio i in repositorioC.FindAllAntecedentes(id))
            {
                listado.Add(CapitulosToListDTOMapper.ToDTO(i));
            }
            return listado;
        }
    }
}
