using Dominio.Exceptions;
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
            if (Password.Length < 8)
                throw new UsuarioException("La contraseña debe tener al menos 8 caracteres.");

            bool mayus = false;
            bool minus = false;
            bool numb = false;
            bool simb = false;

            foreach (char c in Password)
            {
                if (char.IsUpper(c)) mayus = true;
                else if (char.IsLower(c)) minus = true;
                else if (char.IsDigit(c)) numb = true;
                else simb = true;
            }

            if (!mayus)
                throw new UsuarioException("La contraseña debe tener al menos una mayúscula.");
            if (!minus)
                throw new UsuarioException("La contraseña debe tener al menos una minúscula.");
            if (!numb)
                throw new UsuarioException("La contraseña debe tener al menos un número.");
            if (!simb)
                throw new UsuarioException("La contraseña debe tener al menos un carácter especial.");
        }
    }
}
