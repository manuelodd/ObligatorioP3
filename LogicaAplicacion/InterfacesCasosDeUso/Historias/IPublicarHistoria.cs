using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Historias
{
    public interface IPublicarHistoria
    {
        public void Execute(int historiaId, int administradorId);
    }
}
