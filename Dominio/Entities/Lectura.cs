using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    //El sistema debe guardar, para cada lectura: el usuario, la historia,
    //la fecha de inicio, la fecha de finalización (si terminó), y el final alcanzado (si corresponde).
    //Un mismo usuario puede leer la misma historia más de una vez (por ejemplo,
    //para descubrir otros finales) y en cada caso se creará una nueva lectura.
    public class Lectura
    {
        public int Id { get; set; }
        public Usuario Usuario { get;set; }
        public Historia Historia { get; set; }
        public DateTime FechaInicio { get; set; }

        //si corresponden
        public DateTime? FechaFin { get; set; }
        public Final? FinalAlcanzado { get; set; }
    }
}
