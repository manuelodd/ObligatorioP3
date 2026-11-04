using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class CapituloAltaDTO
    {
        public int HistoriaId { get; set; }
        /*
        public int CapituloAntecedenteId { get; set; }
        */
        public int Tipo { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string TextoOpcion { get; set; }
    }
}
