using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.RepositoriosEF.Repositorios
{
    public class RepositorioCapitulosEF : IRepositorioCapitulos
    {
        private HistoriasContext _context;
        public RepositorioCapitulosEF(HistoriasContext context)
        {
            _context = context;
        }
        public void Add(Capitulo nuevo, Opcion opcion)
        {
            nuevo.Validar();
            _context.Capitulos.Add(nuevo);
            _context.Opciones.Add(opcion);
            _context.SaveChanges();
        }

        public void Add(Capitulo nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Capitulo> FindAll()
        {
            throw new NotImplementedException();
        }

        public Capitulo FindById(int id)
        {
            return _context.Capitulos   .Where(c => c.Id == id)
                                        .Include(c => c.Historia)
                                        .FirstOrDefault();
        }

        public Capitulo FindUltimoCapitulo(int historiaId)
        {
            return _context.Capitulos
                                        .Where(c => c.HistoriaId == historiaId)
                                        //el cap cuyo id no esta en SigCap de cualquier Opcion de cualquier capitulo de esa historia, es el 
                                        //ultimo cap =D
                                        .Where(c => !_context.Opciones.Any(o => o.SiguienteCapitulo.Id == c.Id))
                                        .FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Capitulo nuevo)
        {
            throw new NotImplementedException();
        }
    }
}
