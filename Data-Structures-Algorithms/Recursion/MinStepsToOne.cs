//Problem Statement: On a positive integer, you can perform any one of the following 3 steps.
//    1.) Subtract 1 from it. ( n = n - 1 )  ,
//    2.) If its divisible by 2, divide by 2. ( if n % 2 == 0 , then n = n / 2  )  , 
//    3.) If its divisible by 3, divide by 3. ( if n % 3 == 0 , then n = n / 3  ). 
//    Now the question is, given a positive integer n, find the minimum number of steps that takes n to 1

//eg: 1.)For n = 1 , output: 0      
//      2.) For n = 4 , output: 2  ( 4  /2 = 2  /2 = 1 )   
//      3.)  For n = 7 , output: 3  (  7  -1 = 6   /3 = 2   /2 = 1 )

using System;

namespace Algorithms.Problems.Recursion
{
    public class MinStepsToOne
    {
        public static int N;
        public static int[] memo;
        
        //public static void Main()
        //{
        //    N = 20;
        //    memo = new int[N+1];

        //    for (int i = 0; i <= N; i++)
        //        memo[i] = -1;

        //    Console.WriteLine(GetMinSteps1(N));

        //    Console.WriteLine(GetMinSteps2(N));

        //    Console.ReadLine();
        //}

        // 1. Memoization code
        public static int GetMinSteps1(int n)
        {
            if (n == 1)
                return 0;

            if (memo[n] != -1)
                return memo[n];

            int r = 1 + GetMinSteps1(n - 1);

            if (n%2 == 0)
                r = Math.Min(r, 1 + GetMinSteps1(n/2));

            if (n%3 == 0)
                r = Math.Min(r, 1 + GetMinSteps1(n/3));

            memo[n] = r;

            return r;
        }


        // 2. Dynamic programing : bottom up approach
        public static int GetMinSteps2(int n)
        {
            var dp = new int[n + 1];
            dp[1] = 0;

            int i = 2;

            while (i <= n)
            {
                dp[i] = 1 + dp[i - 1];

                if (i%2 == 0)
                    dp[i] = Math.Min(dp[i], 1 + dp[i/2]);

                if (i%3 == 0)
                    dp[i] = Math.Min(dp[i], 1 + dp[i/3]);

                i++;
            }

            return dp[n];
        }
    }
}
