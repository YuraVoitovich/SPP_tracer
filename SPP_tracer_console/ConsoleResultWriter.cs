using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_tracer_console
{
    internal class ConsoleResultWriter : IResultWriter
    {
        public void WriteResult(string result)
        {
            Console.WriteLine(result);
        }


    }
}
