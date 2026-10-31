using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Historias
{
    public interface IEditarHistoria
    {
        public void Execute(HistoriaDTO dto);
    }
}
