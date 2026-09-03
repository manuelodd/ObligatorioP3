using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesDominio;

namespace Dominio.ValueObjects
{
    public class NombreCompletoUsuario : IValidable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
