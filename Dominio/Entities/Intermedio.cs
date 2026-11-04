using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Intermedio : Capitulo
    {
        public Intermedio(string titulo, string texto)  : base(titulo, texto)
        {
        }

        public Intermedio() { }
        public List<Opcion> Opciones { get; set; } = new List<Opcion>();
    }
}
