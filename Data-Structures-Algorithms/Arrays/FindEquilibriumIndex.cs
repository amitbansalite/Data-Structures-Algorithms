using System;

// Find the index i such that : sum of elements less than i = sum of elements greater than i


namespace Algorithms.Problems.Arrays
{
    public class FindEquilibriumIndex
    {
        private int GetEquilibriumIndex(int[] A)
        {
            long sum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i];
            }

            long leftSum = 0;
            long rightSum = sum;
            for (int i = 0; i < A.Length; i++)
            {
                rightSum = sum - leftSum - A[i];
                if (rightSum == leftSum)
                    return i;
                leftSum += A[i];
            }
            return -1;
        }

        public void Test()
        {
            var A1 = new int[] { -7, 1, 5, 2, -4, 3, 0};

            Console.WriteLine("\n The Equilibrium index for array A1 is : {0}", GetEquilibriumIndex(A1));

            Console.WriteLine("\n Press enter key to exit.");
            Console.ReadLine();
        }
    }
}
