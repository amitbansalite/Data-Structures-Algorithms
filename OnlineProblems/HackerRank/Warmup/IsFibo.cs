using System;
using System.Collections.Generic;

namespace Algorithms.Problems.HackerRank.Warmup
{
    public class IsFibo
    {
        public static void Solution()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            
            List<long> fib = new List<long>();
            fib.Add(0);
            fib.Add(1);
            fib.Add(1);

            long currMax = fib[fib.Count-1];

            for (int i = 0; i < T; i++)
            {
                long N = Convert.ToInt64(Console.ReadLine());
                bool found = false;

                if (N == currMax)
                    found = true;
                else if (N < currMax)
                    found = BinarySearch(fib, 0, fib.Count - 1, N);
                else
                    found = UpdateFibSequence(fib, N, ref currMax);

                Console.WriteLine(found ? "IsFibo" : "IsNotFibo");
            }
        }

        private static bool UpdateFibSequence(List<long> fib, long input, ref long currMax)
        {
            long sum = fib[fib.Count - 2] + fib[fib.Count - 1];
            while (sum < input)
            {
                fib.Add(sum);
                sum = fib[fib.Count - 2] + fib[fib.Count - 1];
            }
            fib.Add(sum);
            currMax = sum;

            if (sum == input)
                return true;
            
            return false;
        }

        private static bool BinarySearch(List<long> fib, int lo, int hi, long input)
        {
            while (hi >= lo )
            {
                int mid = lo + (hi - lo) / 2;

                if (fib[mid] == input)
                    return true;
                if (fib[mid] < input)
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }
            return false;
        }
    }
}
