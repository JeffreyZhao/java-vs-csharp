using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using V3.Extensions;

namespace V3.Functional
{
    public static class Samples
    {
        public static Dictionary<char, int> CountDistinctChars(string str)
        {
            return str.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        }

        public static void PrintPoems(string text, int offset)
        {
            text
                .Select((c, i) => new { Char = c, Index = i })
                .GroupBy(c => c.Index % offset, c => c.Char)
                .Select(g => g.Reverse().Join("|"))
                .ForEach(line => Console.WriteLine(line));
        }
    }
}
