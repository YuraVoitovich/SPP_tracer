using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_tracer
{
    public class TracedMethod
    {
        private Stopwatch stopwatch = new Stopwatch();
        public String MethodName { set; get; }

        public String ClassName { set; get; }

        public long Time { set; get; }

        public List<TracedMethod> TracedMethods { get; set; }
       

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
