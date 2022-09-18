using SPP_tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib.Tests
{
    [TestClass]
    public class MultiThreadingTracerTest
    {
        public static readonly object balanceLock = new object();
        public static List<TraceResult> traceResults = new List<TraceResult>();

        public static void AddTraceResult(TraceResult traceResult)
        {
            lock (balanceLock)
            {
                traceResults.Add(traceResult);
            }
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 3; i++)
            {
                Thread myThread = new Thread(foo);
                threads.Add(myThread);
                myThread.Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        private static void foo()
        {
            Tracer tracer = new Tracer();
            MultithreadingTestClass A = new MultithreadingTestClass(tracer);
            A.start();
        }

        [TestMethod]
        public void TestTraceResultsArraySize()
        {
            Assert.AreEqual(3, traceResults.Count);
        }

    }
}
