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
        public string Username { get; set; }
        public UsuarioPassword Password { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Rol.ToString()))
                throw new UsuarioException("Nombre no puede ser vacío.");
            if (string.IsNullOrWhiteSpace(Username))
                throw new UsuarioException("Username no puede ser vacío.");
            NombreCompleto.Validar();
            Email.Validar();
            Password.Validar();
        }
    }


}
