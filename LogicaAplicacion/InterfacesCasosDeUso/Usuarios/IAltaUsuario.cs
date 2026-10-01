using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Usuarios
{
    public interface IAltaUsuario
    {
        public void Execute(UsuarioDTO dto);
    }
}
