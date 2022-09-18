using SPP_tracer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SPP_tracer_console
{
    internal class XMLSerializer : ISerializer
    {
        public string Serialize(List<TraceResult> traceResults)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TraceResult>));
            using (TextWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, traceResults);
                return textWriter.ToString();
            }
        }
    }
}
