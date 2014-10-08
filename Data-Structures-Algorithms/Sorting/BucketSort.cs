using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Bucket sort works as follows:
    //1. Set up an array of initially empty "buckets".
    //2. Scatter: Go over the original array, putting each object in its bucket.
    //3. Sort each non-empty bucket.
    //4. Gather: Visit the buckets in order and put all elements back into the original array

namespace Algorithms.Problems.Sorting
{
    public class BucketSort
    {
        private void Sort(int[] A)
        {
            // get the Range (min, max)
            // create buckets say : (max-min/10)
            // loop over array and assign numbers to appropriate bucket list
            // SORT each bucket : use insertion sort
            // loop over all buckets and append numbers in original list
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
