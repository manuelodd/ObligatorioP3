using Dominio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.ValueObjects
{
    public class UsuarioEmail : IValidable
    {
        public string Email { get; set; }

        public UsuarioEmail(string email)
        {
            this.Email = email;
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
