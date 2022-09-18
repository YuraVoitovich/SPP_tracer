using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPP_tracer;
using SPP_tracer.exception;

namespace TracerLib.Tests
{
    [TestClass]
    public class OneMethodTracerTest
    {

        public static TracedMethod tracedMethod;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            ITracer tracer = new Tracer();
            OneMethodTestClass testClass = new OneMethodTestClass(tracer);
            testClass.TestMethod();
            TraceResult traceResult = tracer.GetTraceResult();
            tracedMethod = traceResult.TracedMethods[0];
        }

        [TestMethod]
        public void TestMethodName()
        {
            TracedMethod excpectedtracedMethod = new TracedMethod();
            excpectedtracedMethod.MethodName = "TestMethod";
            Assert.AreEqual(excpectedtracedMethod.MethodName, tracedMethod.MethodName);
        }

        [TestMethod]
        public void TestClassName()
        {
            TracedMethod excpectedtracedMethod = new TracedMethod();
            excpectedtracedMethod.ClassName = "TracerLib.Tests.OneMethodTestClass";
            Assert.AreEqual(excpectedtracedMethod.ClassName, tracedMethod.ClassName);
        }

        [TestMethod]
        public void TestZeroTime()
        {
            TracedMethod excpectedtracedMethod = new TracedMethod();
            excpectedtracedMethod.Time = 0;
            Assert.AreEqual(excpectedtracedMethod.Time, tracedMethod.Time);
        }

        [ExpectedException(typeof(TracerException), "Exception while calling \"StopTrace\" method without calling \"StartTrace\" method was not throwen")]
        [TestMethod]
        public void TestStopTraceException()
        {
            ITracer tracer = new Tracer();
            tracer.StopTrace();
        }

        [ExpectedException(typeof(TracerException), "Exception while calling \"GetTraceResult\" method without calling \"StopTrace\" method was not throwen")]
        [TestMethod]
        public void TestGetTraceResultException()
        {
            ITracer tracer = new Tracer();
            tracer.StartTrace();
            tracer.GetTraceResult();
        }
    }
}