using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Dominio.Entities;
using DTOs.DTOs;
using Dominio.ValueObjects;

namespace DTOs.Mappers
{
    public static class UsuarioDTOMapper
    {
        public static Usuario FromDTO(UsuarioDTO dto)
        {
            return new Usuario
            {
                Id = dto.Id,
                NombreCompleto = new UsuarioNombreCompleto(dto.Nombre,dto.Apellido),
                //rol xd
                Email = dto.Email,
                Username = dto.Username,
                Password = dto.Password

            };

            /* clase usu
             * public int Id { get; set; }
               public NombreCompletoUsuario NombreCompleto { get; private set; }
               public EmailUsuario Email { get; private set; }
               public RolUsuario Rol { get; set; }
               public string Username { get; set; }
               public string Password { get; set; }
             */
        }

        public static UsuarioDTO ToDTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.NombreCompleto.Nombre,
                Apellido = usuario.NombreCompleto.Apellido,
                Email = usuario.Email,
                Rol = usuario.Rol.ToString(),
                Password = usuario.Password,
                Username = usuario.Username
            };

            /* usuario dto
             * public int Id { get; set; }
               public string Nombre { get; set; }
               public string Apellido { get; set; }
               public string Email { get; set; }
               public int Rol { get; set; }
               public string Username { get; set; }
               public string Password { get; set; }
             */
        }
    }
}
