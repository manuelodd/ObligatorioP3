using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesDominio;

namespace Dominio.Entities
{
    public class Categoria : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
