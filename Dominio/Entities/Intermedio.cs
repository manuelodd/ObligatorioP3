using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Intermedio : Capitulo
    {
        public List<Opcion> Opciones { get; set; }
    }
}
