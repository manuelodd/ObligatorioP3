using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class HistoriaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public List<CategoriaDTO> Categorias { get; set; }
        public List<CapitulosToListDTO> Capitulos { get; set; }
        public List<int> CategoriasId { get; set; }
        public int CapituloInicialId { get; set; }
        public int Estado { get; set; }
        public string TituloCapInicial { get; set; }
        public string TextoCapInicial { get; set; }

    }
}
