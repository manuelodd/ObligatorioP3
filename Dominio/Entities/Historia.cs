using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Enums;
using Dominio.Exceptions;
using Dominio.InterfacesDominio;

namespace Dominio.Entities
{
    public class Historia : IValidable
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();
        public List<Capitulo> Capitulos { get; set; } = new List<Capitulo>();
        public Capitulo CapituloInicial { get; set; }
        public int CapituloInicialId { get; set; }
        public EstadoHistoria Estado { get; set; }
        
        public Historia() { }
        public void Validar()
        {
           
        }
    }
}
