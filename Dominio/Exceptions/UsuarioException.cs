using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entities;

namespace Dominio.Exceptions
{
    public class UsuarioException : Exception
    {
        public UsuarioException() { }
        public UsuarioException(string message) : base(message) { }
        public UsuarioException(string message, Exception innerException) : base(message, innerException){}
    }
}
