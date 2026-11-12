using Dominio.Entities;
using Dominio.Enums;
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
            Intermedio capituloInicial = new Intermedio(
                dto.TituloCapInicial,
                dto.TextoCapInicial
            );

            return new Historia
            {
                Id = dto.Id,
                Titulo = dto.Titulo,
                Sinopsis = dto.Sinopsis,
                Categorias = new List<Categoria>(),
                Estado = (EstadoHistoria)dto.Estado,
                Capitulos = new List<Capitulo>  { 
                                                capituloInicial 
                                                }
            };
        }

        public static HistoriaDTO ToDTO(Historia historia)
        {
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();
            foreach(Categoria cat in historia.Categorias)
            {
                categorias.Add(CategoriaDTOMapper.ToDTO(cat));
            }
            List<CapitulosToListDTO> capitulos = new List<CapitulosToListDTO>();
            foreach(Capitulo cap in historia.Capitulos)
            {
                capitulos.Add(CapitulosToListDTOMapper.ToDTO(cap));
            }
            return new HistoriaDTO
            {
                Id = historia.Id,
                Titulo = historia.Titulo,
                Sinopsis = historia.Sinopsis,
                Categorias = categorias,
                Capitulos = capitulos,
                CapituloInicialId = historia.CapituloInicialId ?? 0,
                Estado = (int)historia.Estado,
                TextoCapInicial = historia.CapituloInicial.Texto,
                TituloCapInicial = historia.CapituloInicial.Titulo
                
            };
        }
    }
}
