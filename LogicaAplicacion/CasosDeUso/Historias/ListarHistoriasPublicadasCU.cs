using Dominio.Entities;
using Dominio.Enums;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Historias
{
    public class ListarHistoriasPublicadasCU : IListarHistoriasPublicadas
    {
        private IRepositorioHistorias repositorio;
        public ListarHistoriasPublicadasCU(     IRepositorioHistorias repo)
        {
            repositorio = repo;
        }
        public List<HistoriaToListDTO> Execute(int? categoriaId)
        {
            List<Historia> historias = repositorio.FindAll()                                            
                                                                .Where(h => h.Estado == EstadoHistoria.PUBLICADA && (categoriaId == null || 
                                                                                                                    h.Categorias.Any(c => c.Id == categoriaId)))
                                                                .ToList();

            List<HistoriaToListDTO> listado = new List<HistoriaToListDTO>();
            foreach(Historia his in historias)
            {
                listado.Add(HistoriaToListDTOMapper.ToDTO(his));
            }
            return listado;
        }
    }
}
