using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Lecturas
{
    public interface IEmpezarLectura
    {
        public Lectura Execute(int usuarioId, int historiaId);
    }
}
