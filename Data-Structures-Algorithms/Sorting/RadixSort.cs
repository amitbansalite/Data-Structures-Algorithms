using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// takes Linear time
// very tricky implenentation ****** look at it *** 
// it is stable implementation. relative ordering is not changing


namespace Algorithms.Problems.Sorting
{
    public class RadixSort
    {
        private int GetMax(int[] A)
        {
            int N = A.Length;
            int largest = A[0];

            for (int i = 1; i < N; i++)
            {
                if (largest < A[i])
                    largest = A[i];
            }
            return largest;
        }

        private void CountSort(int[] A, int currentDigit)
        {
            int N = A.Length;
            int[] output = new int[N];
            int[] count = new int[10];

            // Store count of occurrences in count[]
            for (int i = 0; i < N; i++)
                count[(A[i] / currentDigit) % 10]++;

            // Change count[i] so that count[i] now contains actual position of this digit in output[]
            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array
            for (int i =N-1; i>=0 ; i--)
            {
                var positionToPlace = count[ (A[i] / currentDigit) % 10 ] - 1;
                output[positionToPlace] = A[i];
                count[(A[i] / currentDigit) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now
            // contains sorted numbers according to curent digit
            for (int i = 0; i < N; i++)
                A[i] = output[i];
        }

        private void Sort(int[] A)
        {
            int max = GetMax(A);

            for (int i = 1; max / i > 0; i*=10)
                CountSort(A, i);
        }

        public void Test()
        {
            int[] A = new int[] { 3, 4, 9, 10, 43, 8, 100, 76, 29, 9, 12, 31, 5, 89 };

            Sort(A);

            for (int i = 0; i < A.Length; i++)
                Console.Write(A[i] + " ");

            Console.ReadLine();
        }
    }
}
