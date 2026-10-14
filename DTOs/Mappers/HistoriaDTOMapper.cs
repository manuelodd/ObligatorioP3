using Dominio.Entities;
using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DTOs.Mappers
{
    public static class HistoriaDTOMapper
    {
        public static Historia FromDTO(HistoriaDTO dto)
        {
            List<Categoria> categorias = new List<Categoria>();
            foreach(CategoriaDTO catdto in dto.Categorias)
            {
                categorias.Add(CategoriaDTOMapper.FromDTO(catdto));
            }
            return new Historia
            {
                Id = dto.Id,
                Titulo = dto.Titulo,
                Sinopsis = dto.Sinopsis,
                Categorias = categorias,
                CapituloInicialId = dto.CapituloInicialId,
                Estado = (Dominio.Enums.EstadoHistoria)dto.Estado
            };
        }

        public static HistoriaDTO ToDTO(Historia historia)
        {
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();
            foreach(Categoria cat in historia.Categorias)
            {
                categorias.Add(CategoriaDTOMapper.ToDTO(cat));
            }
            return new HistoriaDTO
            {
                Id = historia.Id,
                Titulo = historia.Titulo,
                Sinopsis = historia.Sinopsis,
                Categorias = categorias,
                CapituloInicialId = historia.CapituloInicial.Id,
                Estado = (int)historia.Estado
            };
        }
    }
}
