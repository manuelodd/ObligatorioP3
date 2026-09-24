using Dominio.InterfacesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.ValueObjects
{
    [Owned]

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
