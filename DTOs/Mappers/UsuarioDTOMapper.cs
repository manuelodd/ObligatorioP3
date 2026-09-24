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
                Rol = (Dominio.Enums.RolUsuario)dto.Rol,
                Email = new UsuarioEmail(dto.Email),
                Username = dto.Username,
                Password = new UsuarioPassword(dto.Password)

            };
        }

        public static UsuarioDTO ToDTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.NombreCompleto.Nombre,
                Apellido = usuario.NombreCompleto.Apellido,
                Email = usuario.Email.Email,
                Rol = (int)usuario.Rol,
                Password = usuario.Password.Password,
                Username = usuario.Username
            };

        }
    }
}
