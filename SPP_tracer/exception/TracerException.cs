using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_tracer.exception
{
    public class TracerException : Exception
    {
        public TracerException(string message) : base(message)
        {

        }

        public TracerException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
