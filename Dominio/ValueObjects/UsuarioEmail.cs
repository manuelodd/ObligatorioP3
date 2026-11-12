using Dominio.Exceptions;
using Dominio.InterfacesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio.ValueObjects
{
    [Owned]

    public class UsuarioEmail : IValidable
    {

        public string Email { get; set; }

        public UsuarioEmail(string email)
        {
            this.Email = email;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Email)) throw new UsuarioException("El email no puede estar vacío.");
        }
    }
}
