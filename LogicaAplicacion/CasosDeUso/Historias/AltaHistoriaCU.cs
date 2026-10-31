using Dominio.Entities;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Historias
{
    public class AltaHistoriaCU : IAltaHistoria
    {
        private IRepositorioHistorias repositorio;
        private IRepositorioCategorias repositorioC;
        public AltaHistoriaCU(IRepositorioHistorias repo, IRepositorioCategorias repoc)
        {
            repositorio = repo;
            repositorioC = repoc;
        }
        /*
        public void Execute(HistoriaDTO dto)
        {
            List<CategoriaDTO> listado = new List<CategoriaDTO>();
            foreach(int idC in dto.CategoriasId)
            {
                listado.Add(CategoriaDTOMapper.ToDTO(repositorioC.FindById(idC)));
            }
            dto.Categorias = listado;
            repositorio.Add(HistoriaDTOMapper.FromDTO(dto));
        }
        */

        public void Execute(HistoriaDTO dto)
        {
            Historia historia = HistoriaDTOMapper.FromDTO(dto);
            historia.Categorias = new List<Categoria>();

            if (dto.CategoriasId != null)
            {
                foreach (int idC in dto.CategoriasId)
                {
                    Categoria categoria = repositorioC.FindById(idC);
                    historia.Categorias.Add(categoria);
                }
            }
            else
            {
                throw new HistoriaException("Debe seleccionar al menos una categoria");
            }
            repositorio.Add(historia);
        }
    }
}
