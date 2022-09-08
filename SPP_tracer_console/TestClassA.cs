using SPP_tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_tracer_console
{
    internal class TestClassA
    {
        private ITracer tracer;
        private TestClassB B;

        public TestClassA(ITracer tracer)
        {
            this.tracer = tracer;
            B = new TestClassB(tracer);
        }

        public void start()
        {
            myMethod();
            myMethod();
            Program.AddTraceResult(tracer.GetTraceResult());
        }
        public void myMethod()
        {
            tracer.StartTrace();
            int x = 0;
            for (int i = 0; i < 1000000; i++)
            {
                x += i;
            }
            B.InnerMethod();
            tracer.StopTrace();
            
        }

    }
}
