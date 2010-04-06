using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace V2.Closures
{
    public static class Parallel
    {
        public static void For(int minInclusive, int maxExlusive, Action<int> action)
        {
            var countdownEvent = new CountdownEvent(maxExlusive - minInclusive);

            WaitCallback worker = delegate(object o)
            {
                action((int)o);
                countdownEvent.ReleaseOne();
            };

            for (var i = minInclusive; i < maxExlusive; i++)
            {
                ThreadPool.QueueUserWorkItem(worker, i);
            }

            countdownEvent.Wait();
        }
    }

    public class CountdownEvent
    {
        public CountdownEvent(int initCount) { }

        public void Wait() { }

        public void ReleaseOne() { }
    }

    public static class ParallelUsage
    {
        public static void Test()
        {
            int n = 1 << 10;
            int[,] array = new int[n, n];

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    array[x, y] = x;
                }
            }

            int sum = ParallelSum(array, n);
        }

        public static int ParallelSum(int[,] array, int n)
        {
            int processorCount = Environment.ProcessorCount;
            int[] result = new int[processorCount];

            Parallel.For(0, processorCount, delegate(int part)
            {
                int partSum = 0;
                int minInclusive = part * n / processorCount;
                int maxExclusive = minInclusive + n / processorCount;

                for (int x = minInclusive; x < maxExclusive; x++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        partSum += array[x, y];
                    }
                }

                result[part] = partSum;
            });

            int sum = 0;
            for (int i = 0; i < result.Length; i++)
            {
                sum += result[i];
            }

            return sum;
        }
    }
}
