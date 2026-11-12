using Dominio.Entities;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class LoginAdminsCU : ILoginAdmins
    {
        private IRepositorioUsuarios repositorio;

        public LoginAdminsCU(IRepositorioUsuarios repo)
        {
            repositorio = repo;
        }

        public UsuarioDTO Execute(LoginDTO dto)
        {
            Usuario usuario = repositorio.Login(dto.Username, dto.Password);
            if (usuario != null)
            {
                return UsuarioDTOMapper.ToDTO(usuario);
            }
            else
            {
                throw new UsuarioException("Credenciales inválidas.");
            }
        }
    }
}
