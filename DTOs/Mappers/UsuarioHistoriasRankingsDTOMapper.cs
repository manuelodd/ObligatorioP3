using Dominio.Entities;
using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Mappers
{
    public class UsuarioHistoriasRankingsDTOMapper
    {
        public static UsuarioHistoriasRankingsDTO ToDTO(Usuario usuario, int cantidad)
        {
            return new UsuarioHistoriasRankingsDTO
            {
                UsuId = usuario.Id,
                NombreCompletoUsu = usuario.NombreCompleto.ToString(),
                CantidadHistoriasCompletadas = cantidad
            };
        }
    }
}
