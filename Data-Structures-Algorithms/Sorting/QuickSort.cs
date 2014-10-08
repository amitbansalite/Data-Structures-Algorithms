using System;

// 3 way quick sort should be used when we know that array has many duplicates


namespace Algorithms.Problems.Sorting
{
    public class QuickSort
    {
        private static void exch(int[] a, int i, int j)
        {
            int tmp = a[j];
            a[j] = a[i];
            a[i] = tmp;
        }

        private int Partition(int[] a, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            while (true)
            {
                while (a[++i] < a[lo])
                    if (i == hi) break;

                while ( a[lo] < a[--j])
                    if (j == lo) break;

                if (i >= j) break;
                exch(a, i, j);
            }
            exch(a, lo, j);
            return j;
        }
                
        private void QSort(int[] a, int lo, int hi)
        {
            if (hi <= lo) return;

            int j = Partition(a, lo, hi);
            QSort(a, lo, j - 1);
            QSort(a, j + 1, hi);
        }


        private static void QuickSort3Way(int[] A, int lo, int hi)
        {
            if (hi <= lo)
                return;

            int lt = lo, gt = hi;
            int i = lo;

            int v = A[lo];

            while (i <= gt)
            {
                if (A[i] < v)
                    exch(A, lt++, i++);
                else if (A[i] > v)
                    exch(A, i, gt--);
                else
                    i++;
            }

            QuickSort3Way(A, lo, lt - 1);
            QuickSort3Way(A, gt + 1, hi);
        }

        public void Test()
        {
            var a = new int[] {23, 5, 5, 91, 10, 30, 56, 5, 23, 23, 4, 89, 67, 91, 5, 4};
            var len = a.Length;

            //QSort(a, 0, len-1);

            QuickSort3Way(a, 0 , len-1);

            for (int i = 0; i < len; i++)
            {
                Console.WriteLine(a[i]);
            }

            Console.WriteLine("\n\n Press enter to exit.");
            Console.ReadLine();
        }
    }
}
