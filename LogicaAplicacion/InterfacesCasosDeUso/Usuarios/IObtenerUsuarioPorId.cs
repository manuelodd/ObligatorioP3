using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Usuario
{
    public interface IObtenerUsuarioPorId
    {
        public UsuarioDTO Execute(int id);
    }
}
