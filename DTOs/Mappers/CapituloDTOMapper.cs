using Dominio.Entities;
using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class CapituloDTOMapper
    {
        public static Capitulo FromDTO(CapituloAltaDTO dto)
        {
            return new Capitulo
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }

        public static CapituloAltaDTO ToDTO(Capitulo categoria)
        {
            return new CapituloAltaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre
            };
        }
    }
}
