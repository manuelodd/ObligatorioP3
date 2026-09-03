using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Opcion
    {
        public string Texto { get; set; }
        public Capitulo SiguienteCapitulo { get; set; }
    }
}
