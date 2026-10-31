using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.RepositoriosEF.Repositorios
{
    public class RepositorioUsuariosEF : IRepositorioUsuarios
    {
        private HistoriasContext _context;
        public RepositorioUsuariosEF(HistoriasContext context)
        {
            _context = context;
        }
        public void Add(Usuario nuevo)
        {
            nuevo.Validar();
            _context.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Usuario> FindAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        }

        public Usuario FindUsuarioByUsername(string username)
        {
            return _context.Usuarios
                                    .Where(u => u.Username == username)
                                    .FirstOrDefault();
        }

        public Usuario Login(string username, string password)
        {
            return _context.Usuarios
                                    .Where(u => u.Username == username && u.Password.Password == password)
                                    .FirstOrDefault();
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
