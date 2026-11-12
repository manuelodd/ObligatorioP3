using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Exceptions;
using Dominio.InterfacesDominio;

namespace Dominio.Entities
{
    public class Opcion : IValidable
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public Capitulo SiguienteCapitulo { get; set; }

        public void Validar()
        {
            if(string.IsNullOrWhiteSpace(Texto)) throw new OpcionException("El texto no puede ser vacío.");
        }
    }
}
