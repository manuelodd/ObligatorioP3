using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;

namespace LogicaAccesoDatos.RepositoriosMemoria
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private static List<Usuario> _usuarios;

        public void Add(Usuario nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario FindUsuarioByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario nuevo)
        {
            throw new NotImplementedException();
        }
    }
}
