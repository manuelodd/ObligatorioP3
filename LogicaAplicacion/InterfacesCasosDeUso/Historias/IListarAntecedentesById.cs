using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Historias
{
    public interface IListarAntecedentesById
    {
        public List<CapitulosToListDTO> Execute(int id);
    }
}
