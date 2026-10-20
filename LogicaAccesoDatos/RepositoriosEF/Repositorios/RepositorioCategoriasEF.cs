using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.RepositoriosEF.Repositorios
{
    public class RepositorioCategoriasEF : IRepositorioCategorias
    {
        private HistoriasContext _context;
        public RepositorioCategoriasEF()
        {
            _context = new HistoriasContext();
        }
        public void Add(Categoria nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> FindAll()
        {
            return _context.Categorias.ToList();
        }

        public Categoria FindById(int id)
        {
            return _context.Categorias.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria nuevo)
        {
            throw new NotImplementedException();
        }
    }
}
