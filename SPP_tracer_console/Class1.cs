using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_tracer_console
{
    class A
    {
        public B b { get; set; }

    }
    class B
    {
        public C c{ get; set; }
    }

    class C
    {
        public A a{ get; set; } // циклическая зависимость, 
                               // может быть на любом уровне вложенности
    }
}
