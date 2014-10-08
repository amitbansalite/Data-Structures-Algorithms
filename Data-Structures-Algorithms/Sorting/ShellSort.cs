using System;

// this sort is same as INSERTION sort but a little faster , O (N ^ 3/2)

// 1. The logic is same as insertion sort
    // instead of comaring the ith elemenet with every element before it as in insertion sort
        // we compare ith elemenet with every (i-h) element


namespace Algorithms.Problems.Sorting
{
    public class ShellSort
    {
        private void Sort(int[] A)
        {
            int N = A.Length;
            int h = 1;

            while (h < N / 3)
                h = 3 * h + 1;

            while (h > 0)
            {   
                // the below for loops are exactly same as insertion sort when h = 1
                for (int i = h; i < N; i++)
                {
                    for (int j = i; j >= h; j-=h )
                    {
                        if (A[j] < A[j - h])
                        {
                            int tmp = A[j - h];
                            A[j - h] = A[j];
                            A[j] = tmp;
                        }
                    }
                }
                h = h / 3;
            }
        }


        public void Test()
        {
            int[] A = new int[]{ 3, 4, 9, 10, 43, 8, 100, 76, 29, 9, 12, 31, 5, 89};            

            Sort(A);

            for (int i=0; i< A.Length; i++)
                Console.Write(A[i]+" ");

            Console.ReadLine();
        }

    }
}
