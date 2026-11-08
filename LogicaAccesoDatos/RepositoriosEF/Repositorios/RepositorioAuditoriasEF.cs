using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.RepositoriosEF.Repositorios
{
    public class RepositorioAuditoriasEF : IRepositorioAuditorias
    {
        private HistoriasContext _context;
        public RepositorioAuditoriasEF(HistoriasContext context)
        {
            _context = context;
        }
        public void Add(Auditoria nuevo)
        {
            nuevo.Validar();
            _context.Auditorias.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Auditoria> FindAll()
        {
            throw new NotImplementedException();
        }

        public Auditoria FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria nuevo)
        {
            throw new NotImplementedException();
        }
    }
}
