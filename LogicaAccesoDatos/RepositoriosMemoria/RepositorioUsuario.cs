using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;

namespace LogicaAccesoDatos.RepositoriosMemoria
{
    public class RepositorioUsuario : IRepositorio<Usuario>
    {
        public static List<Usuario> _usuarios;

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

        public void Remove(Usuario nuevo)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario nuevo)
        {
            throw new NotImplementedException();
        }


    }
}
