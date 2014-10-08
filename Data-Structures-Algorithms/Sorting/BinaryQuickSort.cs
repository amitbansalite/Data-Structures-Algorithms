using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this is preferred than MSD Radix sort 

namespace Algorithms.Problems.Sorting
{
    public class BinaryQuickSort
    {
        private bool GetBit(int num, int pos)
        {
            var res =  (num & (1 << pos)) != 0 ;
            return res;
        }

        private int Partition(int[] A, int start, int end, int bit)
        {
            int i = start;
            int j = end;

            while(i < j)
            {
                while( i < j && GetBit(A[i], bit) == false) i++;
                while( j > i && GetBit(A[j], bit) == true) j--;

                if (i < j)
                {
                    int tmp = A[i];
                    A[i] = A[j];
                    A[j] = tmp;
                }
            }

            if (GetBit(A[i], bit) == false)
                return i;
            else
                return i-1;
        }

        private void QuickSort(int[] A, int start, int end, int bit)
        {
            if (bit < 0 || end <= start)
                return;

            int pivot = Partition(A, start, end, bit);
            
            QuickSort(A, start, pivot, bit-1);
            QuickSort(A, pivot+1, end, bit-1); 
        }

        private int GetMaxBit(int[] A)
        {
            int largest = A[0];
            for (int i=1; i<A.Length; i++)
            {
                if (largest < A[i])
                    largest = A[i];
            }

            int count = 0;
            while (largest > 1)
            {
                count++;
                largest = largest>>1;
            }
            return count;
        }

        public void Test()
        {
            int[] A = new int[] { 3, 1, 4, 0, 5, 7, 2, 6 };

            int bit = GetMaxBit(A);

            QuickSort(A, 0, A.Length-1, bit);

            for (int i = 0; i < A.Length; i++)
                Console.Write(A[i] + " ");

            Console.ReadLine();
        }

    }
}
