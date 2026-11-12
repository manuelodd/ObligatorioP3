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

        public List<Auditoria> FindByFiltros(int? historiaId, int? administradorId)
        {
            List<Auditoria> auditorias = _context.Auditorias.ToList();

            if (historiaId != null)             auditorias = auditorias.Where(a => a.HistoriaId == historiaId).ToList();
            if (administradorId != null)        auditorias = auditorias.Where(a => a.AdministradorId == administradorId).ToList();

            return auditorias;
        }

        public List<Auditoria> FindAll()
        {
            return _context.Auditorias.ToList();
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
