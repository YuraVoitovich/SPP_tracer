using SPP_tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib.Tests
{
    public class MultithreadingTestClass
    {   
        ITracer tracer;

        public MultithreadingTestClass(ITracer tracer)
        {
            this.tracer = tracer;
        }

        public void start()
        {
            InnerMethodsTestClass testClass = new InnerMethodsTestClass(tracer);
            testClass.TestMethod();
            MultiThreadingTracerTest.AddTraceResult(tracer.GetTraceResult());
        }

    }
}
