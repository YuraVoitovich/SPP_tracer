using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_tracer
{
    public class TracedMethod
    {
        private Stopwatch stopwatch = new Stopwatch();
        public String MethodName { internal set; get; }

        public String ClassName { internal set; get; }

        public long Time { internal set; get; }

        public IList<TracedMethod> TracedMethods
        {
            get { return TracedMethods.ToImmutableList(); }
            internal set { TracedMethods = value; }
        }
       

        internal void AddTracedMethod(TracedMethod tracedMethod)
        {
            TracedMethods.Add(tracedMethod);
        }

        internal void StartTrace()
        {
            stopwatch.Start();
        }

        internal void StopTrace()
        {
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }
        public TracedMethod()
        {
            TracedMethods = new List<TracedMethod>();
        }
    }
}
