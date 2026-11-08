using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Capitulos
{
    public interface IAltaCapitulo
    {
        public void Execute(CapituloAltaDTO dto, int administradorId);
    }
}
