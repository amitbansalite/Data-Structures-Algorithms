using System;

namespace Algorithms.Problems.HackerRank
{
    public class Manasa
    {
        public static void Solution()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            int[][] result = new int[T][];

            for (int i = 0; i < T; i++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                
                if (a == b)
                {
                    result[i] = new int[1];
                    result[i][0] = (N - 1) * a;
                }
                else
                {
                    int smallerDiff = 0, higherDiff= 0;
                    if (a < b)
                    {
                        smallerDiff = a;
                        higherDiff = b;
                    }
                    else if (a > b)
                    {
                        smallerDiff = b;
                        higherDiff = a;
                    }

                    int lowestValue = (N - 1) * smallerDiff;
                    result[i] = new int[N];
                    result[i][0] = lowestValue;

                    for (int j = 1; j < N; j++)
                    {
                        result[i][j] = result[i][j - 1] + (higherDiff - smallerDiff);
                    }
                }
                
            }

            for (var i = 0; i < T; i++)
            {
                for (var j = 0; j < result[i].Length; j++)
                {
                    Console.Write("{0} ", result[i][j]);
                }
                Console.WriteLine();
                
            }
        }
    }
}
