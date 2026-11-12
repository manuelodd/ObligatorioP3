using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Auditorias
{
    public interface IListarAuditorias
    {
        public List<AuditoriaDTO> Execute(int? historiaId, int? administradorId);
    }
}
