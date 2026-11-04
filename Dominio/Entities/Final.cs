using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Final : Capitulo
    {
        public Final(string titulo, string texto) : base(titulo, texto)
        {
        }
        public Final() { }
        public int CantidadVecesAlcanzado { get; set; }
    }
}
