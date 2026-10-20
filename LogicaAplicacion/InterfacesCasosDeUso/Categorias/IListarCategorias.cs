using DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.InterfacesCasosDeUso.Categorias
{
    public interface IListarCategorias
    {
        public List<CategoriaDTO> Execute();
    }
}
