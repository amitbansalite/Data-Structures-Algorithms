using System;
using System.Collections.Generic;

namespace Algorithms.Problems.HackerRank
{
    public class Sherlock
    {
        public static void Solution()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            bool[] result = new bool[T];

            for (int i = 0; i < T; i++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                int[] A = new int[N];

                String S = Console.ReadLine();
                string[] nums = S.Split(' ');

                for (int j = 0; j < N; j++)
                {
                    A[j] = Convert.ToInt32(nums[j]);
                }

                result[i] = DoesSubSetExist(A, N);
            }

            for (int i = 0; i < T; i++)
            {
                Console.WriteLine(result[i] ? "YES" : "NO");
            }
        }

        // better approach is to sort and then caaculate GCD of the entire array
        // if 1 then YES or else NO
        private static bool DoesSubSetExist_Refined(int[] A, int N)
        {
            for (int i = 0; i < N; i++)
            {
                if (A[i] == 1)
                    return true;
            }

            Array.Sort(A);
            int currentGcd = GetGCD_Binary(A[0], A[1], 1);
            int j = 2;

            while(j < N)
                currentGcd = GetGCD_Binary(currentGcd, A[j++], 1);
            
            return currentGcd == 1;
        }

        // Naive way to get Gcd of every 2 subsets
        private static bool DoesSubSetExist(int[] A, int N)
        {
            for (int i = 0; i < N; i++)
            {
                if (A[i] == 1)
                    return true;
            }

            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (GetGCD_Binary(A[i], A[j], 1) == 1)
                        return true;
                }
            }
            return false;
        }
      
        private static int GetGCD_Binary(int a, int b, int d)
        {
            if (a == b)
                return a * d;
            if (b == 0)
                return a * d;
            if (a == 0)
                return b * d;

            if (a % 2 == 0 && b % 2 == 0)
                return GetGCD_Binary(a >> 1, b >> 1, d + 1);
            if (a % 2 == 0)
                return GetGCD_Binary(a >> 1, b, d);
            if (b % 2 == 0)
                return GetGCD_Binary(a, b >> 1, d);
            if (a > b)
                return GetGCD_Binary( (a - b) >> 1, b, d);

            return GetGCD_Binary( (b - a) >> 1, a, d);
        }
    }
}
