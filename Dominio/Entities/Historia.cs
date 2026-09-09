using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Enums;
using Dominio.InterfacesDominio;

namespace Dominio.Entities
{
    public class Historia : IValidable
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public List<Categoria> Categorias { get; set; }
        public Capitulo CapituloInicial { get; set; }
        public EstadoHistoria Estado { get; set; }
        

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
