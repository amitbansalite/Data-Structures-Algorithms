using System;

//It may be assumed that the input contains valid digits from 0 to 9 and there are no leading 0′s, no extra trailing 0′s and no two or more consecutive 0′s.

//Input:  digits[] = "121"
//Output: 3
// The possible decodings are "ABA", "AU", "LA"

//Input: digits[] = "1234"
//Output: 3
// The possible decodings are "ABCD", "LCD", "AWD"

namespace Algorithms.Problems.Recursion
{
    public class CountDecoding
    {
        // using Dynamic programing
        // O(N) time and O(N) space
        private void CountDP(char[] digits)
        {
            int N = digits.Length;
            int[] count = new int[N+1];

            count[0] = 1;
            count[1] = 1;

            for (int i = 2; i <= N; i++)
            {
                count[i] = 0;

                if (digits[i - 1] > '0')
                    count[i] = count[i - 1];

                if (digits[i - 2] < '2' || (digits[i - 2] == '2' && digits[i - 1] < '7'))
                    count[i] += count[i - 2];
            }
            Console.WriteLine("No of possible decodings are : {0}", count[N]);
        }

        // using recursion
        private void Count(char[] digits, int n, ref int count)
        {
            if (n == 0 || n == 1)
            {
                count = count+1;
                return;
            }

            if (digits[n - 1] > '0')
                Count(digits, n - 1, ref count);

            if (digits[n - 2] < '2' || (digits[n - 2] == '2' && digits[n - 1] < '7'))
                Count(digits, n - 2, ref  count);
        }

        public void Test()
        {
            var digits1 = "1211";
            var digits2 = "101";
            var digits3 = "121";

            CountDP(digits3.ToCharArray());

            var result = 0;
            Count(digits3.ToCharArray(), digits3.Length, ref result);
            Console.WriteLine("No of possible decodings are : {0}", result);

            Console.WriteLine(" Press enter to exit.");
            Console.ReadLine();
        }
    }
}
