using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesDominio;

namespace Dominio.Entities
{
    public class Opcion : IValidable
    {
        public string Texto { get; set; }
        public Capitulo SiguienteCapitulo { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
