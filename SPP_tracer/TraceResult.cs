using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPP_tracer
{
    public class TraceResult
    {
        public int ThreadId { internal set; get; }

        public long ThreadTime { internal set; get; }

        public IList<TracedMethod> TracedMethods
        { 
            get { return TracedMethods.ToImmutableList();  }
            internal set { TracedMethods = value; }
        }
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
