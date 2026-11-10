using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.RepositoriosEF.Repositorios
{
    public class RepositorioLecturasEF : IRepositorioLecturas
    {
        private HistoriasContext _context;
        public RepositorioLecturasEF(HistoriasContext context)
        {
            _context = context;
        }
        public void Add(Lectura nuevo)
        {
            _context.Lecturas.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Lectura> FindAll()
        {
            throw new NotImplementedException();
        }

        public Lectura FindById(int id)
        {
            return _context.Lecturas    .Where(l => l.Id == id)
                                        .Include(l => l.Usuario)
                                        .Include(l => l.Historia)
                                        .Include(l => l.CapituloActual)
                                            //necesito als opciones del cap actual
                                            .ThenInclude(c => ((Intermedio)c).Opciones)
                                        .Include(l => l.FinalAlcanzado)
                                        .FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Lectura nuevo)
        {
            throw new NotImplementedException();
        }
    }
}
