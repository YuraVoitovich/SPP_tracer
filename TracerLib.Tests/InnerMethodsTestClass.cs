using SPP_tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib.Tests
{
    internal class InnerMethodsTestClass
    {
        ITracer tracer;
        OneMethodTestClass testClass;
        public InnerMethodsTestClass(ITracer tracer)
        {
            this.tracer = tracer;
            testClass = new OneMethodTestClass(tracer);
        }

        public void TestMethod()
        {
            tracer.StartTrace();
            testClass.TestMethod();
            testClass.TestMethod();
            tracer.StopTrace();
        }
    }
}
