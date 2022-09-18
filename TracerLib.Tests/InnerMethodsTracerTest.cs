using SPP_tracer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TracerLib.Tests
{
    [TestClass]
    public class InnerMethodsTracerTest
    {

        public static TraceResult traceResult;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Tracer tracer = new Tracer();
            InnerMethodsTestClass testClass = new InnerMethodsTestClass(tracer);
            testClass.TestMethod();
            testClass.TestMethod();
            traceResult = tracer.GetTraceResult();
        }

        [TestMethod]
        public void TestTracedMethodsArrayCount()
        {
            Assert.AreEqual(2, traceResult.TracedMethods[0].TracedMethods.Count());
        }

        [TestMethod]
        public void TestThreadTime()
        {
            Assert.AreEqual(traceResult.TracedMethods[0].Time + traceResult.TracedMethods[1].Time, traceResult.ThreadTime);
        }
    }
}
