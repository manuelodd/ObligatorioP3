using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioUsuarios : IRepositorio<Usuario>
    {
        public Usuario FindUsuarioByUsername(string username);
        public Usuario Login(string username, string password);
    }
}
