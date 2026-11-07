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

        public void AgregarCapitulo(Intermedio antecedente, Capitulo nuevo, Opcion opcion, int historiaId)
        {
            Intermedio ante = _context.Capitulos
                                                .OfType<Intermedio>()
                                                .Where(c => c.Id == antecedente.Id)
                                                .FirstOrDefault();
            nuevo.HistoriaId = historiaId;
            ante.Opciones.Add(opcion);
            _context.Capitulos.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Intermedio> FindAllAntecedentes(int historiaId)
        {
            return _context.Capitulos
                .OfType<Intermedio>()
                .Where(c => c.HistoriaId == historiaId)
                .ToList();
        }

        public Capitulo FindById(int id)
        {
            return _context.Capitulos.Where(c => c.Id == id)
                                        .Include(c => c.Historia)
                                        .FirstOrDefault();
        }

        public void Add(Capitulo nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Capitulo> FindAll()
        {
            throw new NotImplementedException();
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
