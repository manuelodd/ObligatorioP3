using Dominio.Entities;
using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public static class HistoriaDTOMapper
    {
        public static Historia FromDTO(HistoriaDTO dto)
        {
            return new Historia
            {
                Id = dto.Id,
                Titulo = dto.Titulo,
                Sinopsis = dto.Sinopsis,
                Categorias = dto.Categorias
                    .Select(c => CategoriaDTOMapper.FromDTO(c))
                    .ToList(),
                Estado = (Dominio.Enums.EstadoHistoria)dto.Estado
            };
        }

        public static HistoriaDTO ToDTO(Historia historia)
        {
            return new HistoriaDTO
            {
                Id = historia.Id,
                Titulo = historia.Titulo,
                Sinopsis = historia.Sinopsis,
                Categorias = historia.Categorias
                    .Select(c => CategoriaDTOMapper.ToDTO(c))
                    .ToList(),
                CapituloInicialId = historia.CapituloInicial.Id,
                Estado = (int)historia.Estado
            };
        }
    }
}
