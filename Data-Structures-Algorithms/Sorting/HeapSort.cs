using System;


// think of the heap as 1 => N   (intead of 0=>N-1)
// fpr parent x , [2*x, 2*x+1] are children

namespace Algorithms.Problems.Sorting
{
    public class HeapSort
    {
        private void Sort(int[] A)
        {
            int N = A.Length;

            // sink all elemenets from N/2 => 1
            for (int i = N/2; i >=1; i--)
            {
                Sink(A, i, N);
            }

            while (N>1)     // when N =1 we do not need to sink as there is only one elemenet left
            {
                exch(A, 1, N--);
                Sink(A, 1, N);
            }
        }

        private void Sink(int[] A, int k, int N)
        {
            // there could be only 1 child , hence 2*k <= N
            while (2 * k <= N)          
            {
                int j = 2 * k;
                if (j < N && less(A, j, j + 1)) j++;        // if both child exist then see which one to use
                if (!less(A, k, j)) break;
                exch(A, k, j);
                k = j;                                      // update k
            }
        }

        private void exch(int[] A, int p, int q)
        {
            int tmp = A[p-1];
            A[p-1] = A[q-1];
            A[q-1] = tmp;
        }

        private bool less(int[] A, int p, int q)
        {
            return A[p - 1] < A[q - 1];
        }

        public void Test()
        {
            int[] A = new int[] { 23, 5, 5, 91, 10, 30, 56, 5, 23, 23, 4, 89, 67, 91, 5, 4 };
            
            //int[] A = new int[]{94, 19, 90, 107, 110};
            
            Sort(A);

            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine(A[i]);
            }

            Console.WriteLine("\n\n Press enter to exit.");
            Console.ReadLine();
        }
    }
}
