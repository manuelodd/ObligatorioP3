using Dominio.Entities;
using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public static class CategoriaDTOMapper
    {
        public static Categoria FromDTO(CategoriaDTO dto)
        {
            return new Categoria
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }

        public static CategoriaDTO ToDTO(Categoria categoria)
        {
            return new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre
            };
        }
    }
}
