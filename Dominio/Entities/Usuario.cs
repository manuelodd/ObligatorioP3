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
        public NombreCompletoUsuario NombreCompleto { get; set; }
        public string Email { get; set; }

        //capaz hago herencia para usus
        public RolUsuario Rol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public void Validar()
        {
            throw new NotImplementedException();
        }
    }


}
