using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
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
            return _context.Historias   .Include(h => h.CapituloInicial)
                                        .Include(h => h.Categorias)
                                        .ToList();
                                
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
