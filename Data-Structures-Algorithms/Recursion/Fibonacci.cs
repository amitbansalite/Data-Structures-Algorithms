// 3 ways to do it

    // 1. Memoization : Top down approach : using space proportional to n to store all sub problem results
    
    // 2. DP : Bottom up approach : calculate sub problem results and aggregate to reach the result

    // 3. Plain recursion : generally results in Stackoverflow exception

using System;

namespace Algorithms.Problems.Recursion
{
    public class Fibonacci
    {
        // will result in StackOverflowException as tons of recursive calls for higher values of n
        public static long Bad_Fibonacci(long a)
        {
            if (a == 0)
                return 0;
            if (a == 1)
                return 1;

            return Bad_Fibonacci(a - 1) + Bad_Fibonacci(a - 2);
        }

        // extra memory required propertional to O(n)
        public static long Good_Fibonacci(long a)
        {
            long[] fib = new long[200];

            if (fib[a] == 0)
            {
                if (a == 0 || a == 1)
                    fib[a] = 1;
                else
                    fib[a] = Good_Fibonacci(a - 1) + Good_Fibonacci(a - 2);
            }
            return fib[a];
        }

        // no extra memory required
        public static long non_recursive(long n)
        {
            if (n == 0 || n == 1)
                return 1;

            long sum = 1;
            long previousSum = 0;

            for (int i = 2; i <= n; i++)
            {
                long tmp = sum;
                sum += previousSum;
                previousSum = tmp;
            }
            return sum;
        }

        public void Test()
        {
             //the below statement will hang and will not return an answer
             Console.WriteLine(Bad_Fibonacci(100));

            // the below statement will return an answer in less than 1 sec
            Console.WriteLine(Good_Fibonacci(99));

            Console.WriteLine(non_recursive(100));

            Console.ReadLine();
        }
    }
}
