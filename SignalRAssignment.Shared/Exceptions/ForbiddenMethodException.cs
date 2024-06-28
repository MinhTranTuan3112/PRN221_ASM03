using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.Shared.Exceptions
{
    public class ForbiddenMethodException : ApplicationException
    {
        public ForbiddenMethodException(string message) : base(message)
        {
        }
    }
}