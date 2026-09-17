using Dominio.Entities;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAccesoDatos.RepositoriosMemoria;
using LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class ObtenerUsuarioPorIdCU : IObtenerUsuarioPorId
    {
        private RepositorioUsuarios repositorio;

        public ObtenerUsuarioPorIdCU()
        {
            repositorio = new RepositorioUsuarios();
        }
        public UsuarioDTO Execute(int id)
        {

            foreach(Usuario usuario in repositorio.FindAll())
            {
                if(usuario.Id == id)
                {
                    return UsuarioDTOMapper.ToDTO(usuario);
                }
            }
            return null;
        }
    }
}
