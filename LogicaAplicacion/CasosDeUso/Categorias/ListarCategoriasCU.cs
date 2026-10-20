using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Categorias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Categorias
{
    public class ListarCategoriasCU : IListarCategorias
    {
        private IRepositorioCategorias repositorio;
        public ListarCategoriasCU(IRepositorioCategorias repo)
        {
            repositorio = repo;
        }

        public List<CategoriaDTO> Execute()
        {
            List<CategoriaDTO> listado = new List<CategoriaDTO>();
            foreach(Categoria cat in repositorio.FindAll())
            {
                listado.Add(CategoriaDTOMapper.ToDTO(cat));
            }
            return listado;
        }
    }
}
