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
        public AltaHistoriaCU(IRepositorioHistorias repo, IRepositorioCategorias repositorioc)
        {
            repositorio = repo;
            repositorioC = repositorioc;
        }
        public void Execute(HistoriaDTO dto)
        {
            List<CategoriaDTO> listado = new List<CategoriaDTO>();
            foreach(CategoriaDTO dtoC in dto.Categorias)
            {
                listado.Add(CategoriaDTOMapper.ToDTO(repositorioC.FindById(dtoC.Id)));
            }
            dto.Categorias = listado;
            repositorio.Add(HistoriaDTOMapper.FromDTO(dto));
        }
    }
}
