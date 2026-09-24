using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Enums;
using Dominio.Exceptions;
using Dominio.InterfacesDominio;
using Dominio.ValueObjects;

namespace Dominio.Entities
{
    public class Usuario : IValidable
    {

        public int Id { get; set; }
        public UsuarioNombreCompleto NombreCompleto { get; set; }
        public UsuarioEmail Email { get; set; }

        public RolUsuario Rol { get; set; }

        // VVV datos del login
        public string Username { get; set; }
        public UsuarioPassword Password { get; set; }


        public void Validar()
        {
            if(string.IsNullOrEmpty(Username)) throw new UsuarioException("Username vacío.");
        }
    }


}
