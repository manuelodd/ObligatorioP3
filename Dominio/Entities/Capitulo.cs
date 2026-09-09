using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesDominio;
using Dominio.ValueObjects;

namespace Dominio.Entities
{
    public class Capitulo : IValidable
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; private set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
