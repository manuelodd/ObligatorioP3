using Dominio.Entities;
using Dominio.Exceptions;
using Dominio.ValueObjects;
using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DTOs.Mappers
{
    public static class HistoriaToListDTOMapper
    {

        public static HistoriaToListDTO ToDTO(Historia his)
        {
            return new HistoriaToListDTO
            {
                Id = his.Id,
                Titulo = his.Titulo,
            };

        }
    }
}
