using Dominio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.ValueObjects
{
    public class UsuarioPassword : IValidable
    {
        public string Password {  get; set; }

        public UsuarioPassword(string password)
        {
            this.Password = password;
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
