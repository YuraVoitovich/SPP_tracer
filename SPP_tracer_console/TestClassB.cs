using SPP_tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_tracer_console
{
    internal class TestClassB
    {
        private ITracer tracer;

        public TestClassB(ITracer tracer)
        {
            this.tracer = tracer;
        }

        public void InnerMethod()
        {
            tracer.StartTrace();
            int x = 0;
            for (int i = 0; i < 1000000; i++)
            {
                x += i;
            }
            tracer.StopTrace();
        }
    }
}
