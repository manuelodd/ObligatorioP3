using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;

namespace DTOs.DTOs
{
    public  class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}


/*
 *
 * 
   public int Id { get; set; }
   public NombreCompletoUsuario NombreCompleto { get; private set; }
   public EmailUsuario Email { get; private set; }
   //capaz hago herencia para usus
   public string Rol { get; set; }
   public string Username { get; set; }
   public string Password { get; set; }*
 */
  
