using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesDominio;

namespace Dominio.ValueObjects
{
    public class NombreCompletoUsuario : IValidable
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }

        public NombreCompletoUsuario(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
