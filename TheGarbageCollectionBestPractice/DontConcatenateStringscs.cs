using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarbageCollectionBestPractice
{
    // string methods never modify the original string.
    // instead they always make a copy, modyfy the copy, and return the copy as a result
    //
    // Summary
    // Instead make a copy, modify the copy and return that copy
    // String are optimised for fast comparison, the String Buidler class is optimised for fast modifications
    // Always use StringBuilder in mission critical code
    // In my test program switching from String to StringBuilder reduced memory footprint by 99.9%
    internal class DontConcatenateStringscs
    {
        private const int REPETITIONS = 1000000;
        public void StringTest()
        {
            string result = string.Empty;
            for (int i = 0; i < REPETITIONS; i++)
            {
                result += "#";
            }
        }
        public void StringBuilderTest() 
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0 ; i < REPETITIONS ; i++)
            {
                result.Append("#");
            }
        }
        public void TestMain()
        {
            StringBuilderTest();
        }
    }
}
