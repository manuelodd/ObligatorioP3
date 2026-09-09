using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Enums;
using Dominio.InterfacesDominio;
using Dominio.ValueObjects;

namespace Dominio.Entities
{
    public class Usuario : IValidable
    {

        public int Id { get; set; }
        public UsuarioNombreCompleto NombreCompleto { get; set; }
        public string Email { get; set; }

        public RolUsuario Rol { get; set; }

        // VVV datos del login
        public string Username { get; set; }
        public string Password { get; set; }


        public void Validar()
        {
            throw new NotImplementedException();
        }
    }


}
