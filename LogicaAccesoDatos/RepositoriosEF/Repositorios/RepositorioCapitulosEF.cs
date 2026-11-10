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

        public bool ExisteOpcionEnCapitulo(int opcionId, int capituloId)
        {
            return _context.Capitulos
                                            .OfType<Intermedio>()
                                            .Any(c => c.Id == capituloId && c.Opciones.Any(o => o.Id == opcionId));
        }

        public Capitulo FindById(int id)
        {
            return _context.Capitulos.Where(c => c.Id == id)
                                        .Include(c => c.Historia)
                                        .FirstOrDefault();
        }

        public void Update(Capitulo nuevo)
        {

            Capitulo capitulo = _context.Capitulos
                                                    .Include(c => c.Historia)
                                                    .FirstOrDefault(c => c.Id == nuevo.Id);

            capitulo.Titulo = nuevo.Titulo;
            capitulo.Texto = nuevo.Texto;

            List<Opcion> opciones = _context.Opciones
                                                            .Where(o => o.SiguienteCapitulo.Id == nuevo.Id)
                                                            .ToList();

            foreach (Opcion opcion in opciones)
            {
                opcion.Texto = nuevo.Texto;
            }

            _context.SaveChanges();
        }

        public void IncrementarVecesAlcanzado(int finalId)
        {
            Final final = _context.Finales  .Where(f => f.Id == finalId)
                                            .FirstOrDefault();
            final.CantidadVecesAlcanzado++;
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

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

    }
}
