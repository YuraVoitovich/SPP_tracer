using Newtonsoft.Json;
using SPP_tracer;
using System.Collections.Generic;
using System.IO;

namespace SPP_tracer_console
{
    internal class JSONSerialization : ISerialization
    {
        public string Serialize(List<TraceResult> traceResults)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (TextWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, traceResults);
                return textWriter.ToString();
            }   
        }
    }
}
