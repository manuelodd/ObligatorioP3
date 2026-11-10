using Dominio.Entities;
using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class FinalesAlcanzadosDTOMapper
    {
        public static FinalesAlcanzadosDTO ToDTO(Final final, bool esElMasFrecuente)
        {
            return new FinalesAlcanzadosDTO
            {
                CapFinalId = final.Id,
                Titulo = final.Titulo,
                CantidadVecesAlcanzado = final.CantidadVecesAlcanzado,
                EsElMasFrecuente = esElMasFrecuente
            };
        }
    }
}
