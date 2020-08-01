using System;
using System.Collections.Generic;
using System.Text;

namespace Tandem.Domain.Exceptions
{
    public class TandemValidationException : Exception
    {
        public TandemValidationException(String message) : base(message)
        {
        }

        public List<String> Errors => new List<String> {Message};
    }
}
