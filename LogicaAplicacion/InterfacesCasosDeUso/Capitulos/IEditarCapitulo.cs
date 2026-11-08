using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Capitulos
{
    public interface IEditarCapitulo
    {
        public void Execute(CapitulosToListDTO dto, int administradorId);
    }
}
