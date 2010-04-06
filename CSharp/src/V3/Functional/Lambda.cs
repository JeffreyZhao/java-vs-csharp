using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace V3.Functional
{
    public static class Lambda
    {
        public static void AllTheSame()
        {
            Func<int, int, int> max1 = delegate(int a, int b)
            {
                if (a > b)
                {
                    return a;
                }
                else
                {
                    return b;
                }
            };

            Func<int, int, int> max2 = (int a, int b) =>
            {
                if (a > b)
                {
                    return a;
                }
                else
                {
                    return b;
                }
            };

            Func<int, int, int> max3 = (a, b) =>
            {
                if (a > b)
                {
                    return a;
                }
                else
                {
                    return b;
                }
            };

            Func<int, int, int> max4 = (a, b) => a > b ? a : b;
        }
    }
}
