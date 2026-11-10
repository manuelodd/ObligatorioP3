using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.RepositoriosEF.Repositorios
{
    public class RepositorioOpcionesEF : IRepositorioOpciones
    {
        private HistoriasContext _context;

        public RepositorioOpcionesEF(HistoriasContext context)
        {
            _context = context;
        }

        public void Add(Opcion nuevo)
        {
            _context.Opciones.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Opcion> FindAll()
        {
            return _context.Opciones.ToList();
        }

        public Opcion FindById(int id)
        {
            return _context.Opciones
                            .Include(o => o.SiguienteCapitulo)
                             .FirstOrDefault(o => o.Id == id);
        }

        public void Remove(int id)
        {
            Opcion opcion = FindById(id);

            if (opcion != null)
            {
                _context.Opciones.Remove(opcion);
                _context.SaveChanges();
            }
        }

        public void Update(Opcion nuevo)
        {
            _context.Opciones.Update(nuevo);
            _context.SaveChanges();
        }
    }
}