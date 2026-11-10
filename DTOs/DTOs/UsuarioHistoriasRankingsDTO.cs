using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.DTOs
{
    public class UsuarioHistoriasRankingsDTO
    {
        public int UsuId { get; set; }
        public string NombreCompletoUsu { get; set; }
        public int CantidadHistoriasCompletadas { get; set; }
    }
}
