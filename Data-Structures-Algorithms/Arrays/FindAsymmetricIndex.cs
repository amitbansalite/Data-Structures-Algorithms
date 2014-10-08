using System;

/*
P ( T ) for 0 ≤ T < N is the number of indices I such that 0 ≤ I < T and A[I] = X,
Q ( T ) for 0 ≤ T < N is the number of indices J such that T ≤ J < N and A[J] ≠ X.
The 'asymmetry index' is an index K such that 0 ≤ K < N and P ( K ) = Q ( K )
*/

namespace Algorithms.Problems.Arrays
{
    public class FindAsymmetricIndex
    {
        private static int Solution(int X, int[] A, int N)
        {
            int P = 0, Q = 0;
            int currentBest = 0;
            for (int i = 0; i < N; i++)
            {
                if (P == Q)
                    currentBest = i;
                if (A[i] == X && Q != 0)
                {
                    P++;
                    Q = 0;
                }
                else if (A[i] == X)
                    P++;
                else
                    Q++;
            }

            if (currentBest > 0 && currentBest < N)
                return currentBest;

            return -1;
        }

        public static void Test(string[] args)
        {
            var X = 5;

            var A1 = new int[]{5, 5, 1, 7, 2, 3, 5};
            var A2 = new int[] { 5, 5, 1, 7, 5, 3, 5 };

            Console.WriteLine("\n The Asymmetric index for array A1 is : {0}", Solution(X, A1, A1.Length));
            Console.WriteLine("\n The Asymmetric index for array A2 is : {0}", Solution(X, A2, A2.Length));

            Console.WriteLine("\n Press enter key to exit.");
            Console.ReadLine();
        }

    }
}
