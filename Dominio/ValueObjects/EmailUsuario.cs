using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesDominio;

namespace Dominio.ValueObjects
{
    public class EmailUsuario : IValidable
    {
        public string Email { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
