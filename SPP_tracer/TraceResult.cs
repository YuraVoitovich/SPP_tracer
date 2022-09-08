using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPP_tracer
{ 
    public class TraceResult
    {
        public int ThreadId { set; get; }

        public long ThreadTime { set; get; }

        public List<TracedMethod> TracedMethods { get; internal set; }
        public TraceResult()
        {
            TracedMethods = new List<TracedMethod>();
        }
       

        internal void AddTracedMethod(TracedMethod tracedMethod)
        {
            TracedMethods.Add(tracedMethod);
        }
    }
}
