using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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

        public Capitulo(string titulo, string texto) {
            Titulo = titulo;
            Texto = texto;
        }

        public Capitulo() { }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
