using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Lecturas
{
    public interface ISeguirLectura
    {
        public Lectura Execute(int lecturaId, int opcionId);
    }
}
