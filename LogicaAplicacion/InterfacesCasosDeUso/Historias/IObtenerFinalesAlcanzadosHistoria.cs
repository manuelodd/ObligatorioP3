using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Historias
{
    public interface IObtenerFinalesAlcanzadosHistoria
    {
        public List<FinalesAlcanzadosDTO> Execute(int historiaId);
    }
}
