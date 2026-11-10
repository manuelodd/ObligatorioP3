using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Lecturas
{
    public interface IObtenerCapituloLectura
    {
        public CapituloLecturaDTO Execute(int lecturaId);
    }
}
