using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarbageCollectionBestPractice
{
    // Boxing / unboxing is a process that let you use value types and reference types interchanguably in you code.
    // Each boxing operation creates a new object on the heap. A boxed object occupies more memory thn the original value type.
    // - Boxing floods the heap with lots of small objects and puts considerable pressure on the garbage collector.
    // - Boxing and unboxing should be avoided wherever possible
    public class AvoidBoxingUnboxing
    {
        public const int ITERATIONS = 1000000;

        public void TestMethod(int value)
        {

        }
        public void TestMain()
        {
            for (int i = 0; i < ITERATIONS; i++)
            {
                TestMethod(i);
            }
        }
    }
}
