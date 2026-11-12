using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Exceptions
{
    public class OpcionException : Exception
    {
        public OpcionException() { }
        public OpcionException(string message) : base(message) { }
        public OpcionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
