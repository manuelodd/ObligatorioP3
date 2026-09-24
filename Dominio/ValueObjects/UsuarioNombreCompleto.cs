using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesDominio;
using Microsoft.EntityFrameworkCore;

namespace Dominio.ValueObjects
{
    [Owned]

    public class UsuarioNombreCompleto : IValidable
    {
    
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }

        public UsuarioNombreCompleto(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
