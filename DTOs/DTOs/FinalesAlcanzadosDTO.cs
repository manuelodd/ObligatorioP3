using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class FinalesAlcanzadosDTO
    {
        public int CapFinalId { get; set; }
        public string Titulo { get; set; }
        public int CantidadVecesAlcanzado { get; set; }
        public bool EsElMasFrecuente { get; set; }
    }
}
