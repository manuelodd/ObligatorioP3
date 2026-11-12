using Dominio.Exceptions;
using Dominio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    //El sistema debe guardar, para cada lectura: el usuario, la historia,
    //la fecha de inicio, la fecha de finalización (si terminó), y el final alcanzado (si corresponde).
    //Un mismo usuario puede leer la misma historia más de una vez (por ejemplo,
    //para descubrir otros finales) y en cada caso se creará una nueva lectura.
    public class Lectura : IValidable
    {
        public int Id { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Historia Historia { get; set; }
        public int HistoriaId { get; set; }
        public Capitulo CapituloActual { get; set; }
        public int CapituloActualId { get; set; }
        public Final FinalAlcanzado { get; set; }
        public int? FinalAlcanzadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public void Validar()
        {
            if (UsuarioId <= 0)         throw new LecturaException("El usuario es invalido.");
            if (HistoriaId <= 0)        throw new LecturaException("La historia es invalida.");
            if (CapituloActualId <= 0)  throw new LecturaException("El capítulo actual es invalido.");
            if (FechaInicio == default) throw new LecturaException("La fecha de inicio es obligatoria.");
            if (FechaFin.HasValue && FechaFin.Value < FechaInicio)  
                                            throw new LecturaException("La fecha de finalizacion no puede ser anterior a la fecha de inicio.");
        }
    }
}
