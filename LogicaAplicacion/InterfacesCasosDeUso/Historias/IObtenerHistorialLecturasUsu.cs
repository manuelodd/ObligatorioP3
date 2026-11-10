using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Historias
{
    public interface IObtenerHistorialLecturasUsu
    {
        public List<LecturaHistorialDTO> Execute(int usuarioId, int mes, int anio);
    }
}
