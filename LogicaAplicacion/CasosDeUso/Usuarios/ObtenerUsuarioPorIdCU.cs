using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class ObtenerUsuarioPorIdCU : IObtenerUsuarioPorId
    {
        private IRepositorioUsuarios repositorio;

        public ObtenerUsuarioPorIdCU(IRepositorioUsuarios repo)
        {
            repositorio = repo;
        }
        public UsuarioDTO Execute(int id)
        {
            return UsuarioDTOMapper.ToDTO(repositorio.FindById(id));
        }
    }
}
