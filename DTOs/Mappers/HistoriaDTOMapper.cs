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
            return new Historia
            {
                Id = dto.Id,
                Titulo = dto.Titulo,
                Sinopsis = dto.Sinopsis,
                Categorias = new List<Categoria>(),
                CapituloInicialId = dto.CapituloInicialId,
                Estado = (Dominio.Enums.EstadoHistoria)dto.Estado,
                CapituloInicial = new Intermedio(dto.TituloCapInicial, dto.TextoCapInicial)
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
                // por si el capitulo inicial todavia no existe (mayoria de casos) no tire errores SACAR DESPUES
                CapituloInicialId = historia.CapituloInicial?.Id ?? 0,
                Estado = (int)historia.Estado,
                TextoCapInicial = historia.CapituloInicial?.Texto,
                TituloCapInicial = historia.CapituloInicial.Titulo
                
            };
        }
    }
}
