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
    public class ObtenerRankingsHistoriasCU : IObtenerRankingsHistorias
    {
        private IRepositorioLecturas repositorio;

        public ObtenerRankingsHistoriasCU(IRepositorioLecturas repo)
        {
            repositorio = repo;
        }

        public List<HistoriaRankingsDTO> Execute()
        {
            List<Lectura> lecturas = repositorio.FindAll() 
                                                            .Where(l => l.FechaFin != null)
                                                            .ToList();

            List<HistoriaRankingsDTO> ranking = new List<HistoriaRankingsDTO>();

            foreach (Lectura lectura in lecturas)
            {

                bool yaEstaEnRanking = ranking.Any(r => r.HistoriaId == lectura.HistoriaId);

                if (!yaEstaEnRanking)
                {
                    int cantidad = lecturas.Count(l => l.HistoriaId == lectura.HistoriaId);

                    ranking.Add(HistoriasRankingsDTOMapper.ToDTO(lectura.Historia, cantidad));
                }
            }

            return ranking.OrderByDescending(r => r.CantidadVecesCompletadas).ToList();
        }
    }
}
