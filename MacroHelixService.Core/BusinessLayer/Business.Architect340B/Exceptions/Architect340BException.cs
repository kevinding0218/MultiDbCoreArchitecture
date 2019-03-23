using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Architect340B.Exceptions
{
    public class Architect340BException : Exception
    {
        public Architect340BException()
            : base()
        {
        }

        public Architect340BException(String message)
            : base(message)
        {
        }

        public Architect340BException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
