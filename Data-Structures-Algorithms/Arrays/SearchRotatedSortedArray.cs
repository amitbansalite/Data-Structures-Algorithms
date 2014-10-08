using System;

// *********** Very very important question *********** //

namespace Algorithms.Problems.Arrays
{
    public class SearchRotatedSortedArray
    {
        private int? BinarySearch(int[] a, int input)
        {
            int low = 0;
            int high = a.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (input == a[mid])
                    return mid;

                else if (a[mid] < input)
                    low = mid - 1;
                else if (input < a[mid])
                    high = mid + 1;
            }
            return null;
        }

        private int? BinarySearch(int[] a, int low, int high, int input)
        {
            if (low > high)
                return null;

            int mid = low + (high - low) / 2;

            if (input == a[mid])
                return mid;
            
            if (input < a[mid] )
            {
                high = mid - 1;
            }
            else if (input > a[mid])
            {
                low = mid + 1;            
            }
            return BinarySearch(a, low, high, input);
        }

        // search given element in rotated sorted array
        private int? Search(int[] a, int input)
        {
            int low = 0;
            int high = a.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (input == a[mid])
                    return mid;

                if (a[low] <= a[mid])
                {
                    if (a[low] <= input && input < a[mid])
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                else 
                {
                    if (a[mid] < input && input <= a[high])
                        low = mid + 1; 
                    else
                        high = mid - 1;
                }
            }
            return null;
        }

        private int SearchPivot(int[] a)
        {
            int low = 0;
            int high = a.Length - 1;

            while (a[low] > a[high])
            {
                int mid = low + (high - low)/2;

                if (a[mid] > a[high])
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }

        public void Test()
        {
            //var arr = new int[10]{1, 3, 6, 7, 8, 11, 13, 17, 19, 20};
            //var result = BinarySearch(arr, 17);
            //var result = BinarySearch(arr, 0, 9, 1);
            //var result = Search(arr, 16);

            var arr = new int[20]{17, 18, 19, 20, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
            var result = SearchPivot(arr);

            //if (result != null)
            //    Console.WriteLine("Element found at position {0}", result);
            //else
            //    Console.WriteLine("Element not found");

            Console.WriteLine(" Pivot found at position : {0}", result);

            Console.WriteLine("\n Press enter key to exit.");
            Console.ReadLine();
        }
    }
}
