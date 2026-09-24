using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class AltaUsuarioCU : IAltaUsuario
    {
        private IRepositorioUsuarios repositorio;
        public AltaUsuarioCU(IRepositorioUsuarios repo)
        {
            repositorio = repo;
        }
        public void Execute(UsuarioDTO dto)
        {
            repositorio.Add(UsuarioDTOMapper.FromDTO(dto));
        }
    }
}
