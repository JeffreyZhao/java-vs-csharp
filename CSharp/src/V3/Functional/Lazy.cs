using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace V3.Functional
{
    public static class Lazy
    {
        public static IEnumerable<int> AllNaturalNumber()
        { 
            int i = 1;
            while (true) yield return (i++);
        }
    }
}
