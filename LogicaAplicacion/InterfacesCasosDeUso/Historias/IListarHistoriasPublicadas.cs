using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Historias
{
    public interface IListarHistoriasPublicadas
    {
        public List<HistoriaToListDTO> Execute(int? categoriaId);
    }
}
