using System;
using System.Collections.Generic;
using System.Linq;

// this same code can be used to SORT List<String> in O(N) time
    // it uses 2N extra space 

namespace Algorithms.Problems.Sorting
{
    public class MSD_RadixSort
    {
        private void CountSort(List<int> A, int currentDigit, ref int[] output, ref int index)
        {
            int N = A.Count;
            var count = new List<int>[10];
            
            for (int i = 0; i < 10; i++)
                count[i] = new List<int>();

            for (int i = 0; i < N; i++)
                count[(A[i] / currentDigit) % 10].Add(A[i]);

            for (int i = 0; i < 10; i++)
            {
                if (count[i].Count > 1)
                {
                    if (currentDigit > 1 )
                        CountSort(count[i], currentDigit / 10, ref output, ref index);
                    else
                    {
                        for (int j = 0; j < count[i].Count; j++)
                            output[index++] = count[i][j];
                    }
                }
                    
                else if (count[i].Count == 1)
                    output[index++] = count[i][0];
            }
        }

        private int MSD(int[] A)
        {
            int N = A.Length;
            int largest = A[0];

            for (int i = 1; i < N; i++)
            {
                if (largest < A[i])
                    largest = A[i];
            }

            int tmp = largest;
            int j=1;
            while (tmp > 0)
            {
                j = j*10;
                tmp = tmp / 10;
            }

            return j / 10;
        }

        public void Test()
        {
            int[] A = new int[] { 3, 467, 906, 10, 43, 89, 10, 100, 76, 29, 9, 12, 31, 5, 869, 467 };           
            var output = new int[A.Length];

            var exp = MSD(A);
            int index = 0;
            CountSort(A.ToList(), exp, ref output, ref index);

            for (int i = 0; i < output.Length; i++)
                Console.Write(output[i] + " ");

            Console.ReadLine();
        }
    }
}
