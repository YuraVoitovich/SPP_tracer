using SPP_tracer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib.Tests
{
    internal class OneMethodTestClass
    {
        private ITracer tracer;

        public OneMethodTestClass(ITracer tracer)
        {
            this.tracer = tracer;
        }

        public void TestMethod()
        {
            tracer.StartTrace();
            tracer.StopTrace();
        }
    }
}
