using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class CategoriaException : Exception
    {
        public CategoriaException() { }
        public CategoriaException(string message) : base(message) { }
        public CategoriaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
