using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;

namespace LogicaAccesoDatos.RepositoriosMemoria
{
    public class RepositorioUsuario
    {
        public static List<Usuario> _usuarios;

        //para IRepositorio<T>
        public void Alta(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new UsuarioException("Usuario vacio");
            }

            usuario.Validar();
        }
    
}
}
