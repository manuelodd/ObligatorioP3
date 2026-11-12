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
        public RepositorioHistoriasEF(HistoriasContext context)
        {
            _context = context;
        }

        public void Add(Historia nuevo)
        {
            nuevo.CapituloInicial = null;

            // Guardamos la historia y sus capítulos.
            _context.Historias.Add(nuevo);
            _context.SaveChanges();

            // Ahora el capítulo ya tiene su Id.
            Capitulo inicial = nuevo.Capitulos[0];

            // Establecemos la relación con el capítulo inicial.
            nuevo.CapituloInicial = inicial;
            nuevo.CapituloInicialId = inicial.Id;

            _context.SaveChanges();
        }

        public List<Historia> FindAll()
        {
            return _context.Historias
                .Include(h => h.CapituloInicial)
                .Include(h => h.Capitulos)
                .Include(h => h.Categorias)
                .ToList();
        }

        public Historia FindById(int id)
        {
            return _context.Historias   .Where(h => h.Id == id)
                                        .Include(h => h.Capitulos)
                                            .ThenInclude(c => ((Intermedio)c).Opciones)
                                        .Include(h => h.CapituloInicial)
                                        .FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Historia nuevo)
        {
            nuevo.Validar();
            _context.Historias.Update(nuevo);
            _context.SaveChanges();
        }

        public bool TieneMasDeUnCapitulo(int idHistoria)
        {
            return _context.Historias
                                                .Where(h => h.Id == idHistoria)
                                                .SelectMany(h => h.Capitulos)
                                                .Count() > 1;
        }
    }
}
