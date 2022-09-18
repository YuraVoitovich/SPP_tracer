using SPP_tracer.exception;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPP_tracer
{
    public class Tracer : ITracer
    {
        private TraceResult traceResult = new TraceResult();

        private Stack<TracedMethod> stack = new Stack<TracedMethod>();

        public Tracer()
        {
            traceResult.ThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        public TraceResult GetTraceResult()
        {
            if (stack.Count != 0)
            {
                throw new TracerException("Method \"StopTrace\" not called for all \"StartTrace\" mehtods");
            }
            return traceResult;
        }

        public void StartTrace()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            TracedMethod tracedMethod = new TracedMethod();
            if (stack.Count == 0)
            {
                stack.Push(tracedMethod);
                traceResult.AddTracedMethod(tracedMethod);
            } else
            {
                stack.Peek().AddTracedMethod(tracedMethod);
                stack.Push(tracedMethod);
            }
            tracedMethod.MethodName = methodBase.Name;
            tracedMethod.ClassName = methodBase.DeclaringType.FullName;
            tracedMethod.StartTrace();
        }

        public void StopTrace()
        {
            if (stack.Count == 0)
            {
                throw new TracerException("The method \"StopTrace\" cannot be called before the method \"StartTrace\" is called"); 
            }
            stack.Peek().StopTrace();
            traceResult.ThreadTime += stack.Peek().Time;
            stack.Pop();
        }
    }
}
