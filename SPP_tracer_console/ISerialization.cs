using SPP_tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_tracer_console
{
    internal interface ISerialization
    {
        String Serialize(List<TraceResult> traceResults);
    }
}
