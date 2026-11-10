using Dominio.Entities;
using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{

    public static class HistoriasRankingsDTOMapper
    {
        public static HistoriaRankingsDTO ToDTO(Historia historia, int cantidad)
        {
            return new HistoriaRankingsDTO
            {
                HistoriaId = historia.Id,
                Titulo = historia.Titulo,
                CantidadVecesCompletadas = cantidad
            };
        }
    }
}
