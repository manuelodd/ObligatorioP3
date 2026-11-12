using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioAuditorias : IRepositorio<Auditoria>
    {
        public List<Auditoria> FindByFiltros(int? historiaId, int? administradorId);
    }
}
