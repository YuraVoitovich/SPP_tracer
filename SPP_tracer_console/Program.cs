using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SPP_tracer;

namespace SPP_tracer_console
{
    internal class Program
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

        private static void foo()
        {
            Tracer tracer = new Tracer();
            TestClassA A = new TestClassA(tracer);
            A.start();
        }
        static void Main(string[] args)
        {   
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                Thread myThread = new Thread(foo);
                threads.Add(myThread);
                myThread.Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            ISerializer serialization = new XMLSerializer();
            IResultWriter resultWriter = new ConsoleResultWriter();
            IResultWriter resultFileWriter = new FileResultWriter("D:\\lol.txt");
            string result = serialization.Serialize(traceResults);
            resultWriter.WriteResult(result);
            resultFileWriter.WriteResult(result);
            Console.Read();
        }
    }
}
