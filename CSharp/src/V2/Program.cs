using System;
using System.Collections.Generic;
using System.Text;
using V2.Yields;

namespace V2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            foreach (var i in FibonacciGenerator.GenerateWithYield())
            {
                Console.WriteLine(i);
                if (count++ == 10) break;
            }

            Console.ReadLine();
        }
    }
}
