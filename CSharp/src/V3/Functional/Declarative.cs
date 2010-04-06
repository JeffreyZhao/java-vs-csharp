using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace V3.Functional
{
    public static class Declarative
    {
        public static Dictionary<char, List<string>> CreateIndex(IEnumerable<string> keywords)
        {
            // define an Dictionary
            var result = new Dictionary<char, List<string>>();

            // fill the dictionary
            foreach (var kw in keywords)
            {
                var firstChar = kw[0];
                List<string> groupKeywords;

                if (!result.TryGetValue(firstChar, out groupKeywords))
                {
                    groupKeywords = new List<string>();
                    result.Add(firstChar, groupKeywords);
                }

                groupKeywords.Add(kw);
            }

            // sort the keywords of each group
            foreach (var groupKeywords in result.Values)
            {
                groupKeywords.Sort();
            }

            return result;
        }

        public static Dictionary<char, List<string>> CreateIndexByLambda(IEnumerable<string> keywords)
        {
            return keywords
                .GroupBy(k => k[0])
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderBy(k => k).ToList());
        }

        static List<int> GetSquaresOfEven(List<string> strList)
        {
            List<int> intList = new List<int>();
            foreach (var s in strList) intList.Add(Int32.Parse(s));

            List<int> evenList = new List<int>();
            foreach (int i in intList)
            {
                if (i % 2 == 0) evenList.Add(i);
            }

            List<int> squareList = new List<int>();
            foreach (int i in evenList) squareList.Add(i * i);

            squareList.Sort();
            return squareList;
        }

        static List<int> GetSquaresOfEvenByLambda(List<string> strList)
        {
            return strList
                .Select(s => Int32.Parse(s)) // parse to int
                .Where(i => i % 2 == 0) // choose the even number only
                .Select(i => i * i) // calculate square of each
                .OrderBy(i => i) // sort
                .ToList(); // create a list
        }
    }
}
