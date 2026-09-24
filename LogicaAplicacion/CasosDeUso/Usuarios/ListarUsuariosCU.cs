using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class ListarUsuariosCU : IListarUsuarios
    {
        private IRepositorioUsuarios repositorio;

        public ListarUsuariosCU(IRepositorioUsuarios repo)
        {
            repositorio = repo;
        }

        public List<UsuarioDTO> Execute()
        {
            List<UsuarioDTO> listado = new List<UsuarioDTO>();
            foreach(Usuario usuario in repositorio.FindAll())
            {
                listado.Add(UsuarioDTOMapper.ToDTO(usuario));
            }

            return listado;
        }
    }
}
