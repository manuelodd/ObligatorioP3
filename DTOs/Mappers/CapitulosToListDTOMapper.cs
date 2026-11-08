using Dominio.Entities;
using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public static class CapitulosToListDTOMapper
    {

        public static CapitulosToListDTO ToDTO(Capitulo capitulo)
        {
            return new CapitulosToListDTO
            {
                CapId = capitulo.Id,
                CapTitulo = capitulo.Titulo,
                CapTexto = capitulo.Texto
            };
        }
    }
}
