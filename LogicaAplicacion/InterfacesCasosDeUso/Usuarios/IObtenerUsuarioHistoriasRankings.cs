using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Usuarios
{
    public interface IObtenerUsuarioHistoriasRankings
    {
        public List<UsuarioHistoriasRankingsDTO> Execute();
    }
}
