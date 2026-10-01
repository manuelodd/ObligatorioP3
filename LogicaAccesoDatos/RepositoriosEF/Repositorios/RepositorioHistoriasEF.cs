using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.RepositoriosEF.Repositorios
{
    public class RepositorioHistoriasEF : IRepositorioHistorias
    {
        private HistoriasContext _context;
        public RepositorioHistoriasEF()
        {
            _context = new HistoriasContext();
        }

        public void Add(Historia nuevo)
        {
            nuevo.Validar();
            _context.Historias.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Historia> FindAll()
        {
            throw new NotImplementedException();
        }

        public Historia FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Historia nuevo)
        {
            throw new NotImplementedException();
        }
    }
}
