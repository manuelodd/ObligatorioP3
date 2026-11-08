using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Historias
{
    public interface IAltaHistoria
    {
        public void Execute(HistoriaDTO dto, int administradorId);
    }
}
