using Dominio.Exceptions;
using Dominio.InterfacesDominio;
using Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Dominio.Entities
{
    public class Capitulo : IValidable
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int HistoriaId { get; set; }
        public Historia Historia { get; set; }

        public Capitulo(string titulo, string texto) {
            Titulo = titulo;
            Texto = texto;
        }

        public Capitulo() { }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Titulo))      throw new CapituloException("El titulo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(Texto))       throw new CapituloException("El texto no puede estar vacío.");
        }
    }
}
