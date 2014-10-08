using System;
using System.Collections.Generic;

// very similar to : http://www.geeksforgeeks.org/find-if-there-is-a-subarray-with-0-sum/
    //little modification in the DP relationship and start condition

namespace Algorithms.Problems.DP
{
    public class SubArrayWithGivenSum
    {
        // It can contain +ve, 0 and -ve numbers
            // approach used : DP
        private static void PrintSubArrayWithGivenSum(int[] a, int k)
        {
            // represents <sum from start upto that index, index> 
            var hashMap = new Dictionary<int, int>();
            hashMap.Add(0,-1);

            int currSum = 0;

            for (int i = 0; i < a.Length ; i++)
            {
                currSum += a[i];
                
                if (hashMap.ContainsKey(currSum - k))
                {
                    var index = hashMap[currSum -k];
                    Console.WriteLine(" Sub array that sums upto {0} start from index {1} and ends at index {2}", k, index+1, i);
                    break;
                }
                if (! hashMap.ContainsKey(currSum))
                        hashMap.Add(currSum, i);
            }
        }
        
        // sub array : cannot have any 2 adjacent elements
            // think in the way that should you taking selecting a[i] or NOT
        private static int GetSubArrayWithMaxSum_NoAdjacent_Elements(int[] a)
        {
            var s = new int[a.Length];
            s[0] = a[0];
            s[1] = a[1];
            
            for (int i = 2; i < a.Length; i++)
            {
                s[i] = Math.Max( (s[i - 2] + a[i]), s[i - 1] );
            }

            return s[a.Length-1];
        }

        
        public void Test()
        {
            //var input1 = new[] { 5, 0, 9, 2, 5, 5, 5 };
            //var input2 = new[] { 10};
            //var input3 = new[] { -20, 0, 30, 0, 5};
            //var input4 = new[] { -20, -7, 35, 0, 2, 0, 5};
            //var input5 = new[] { 5, 5, -6, 6, 0, 0 };
            
            //PrintSubArrayWithGivenSum(input1, 10);
            //PrintSubArrayWithGivenSum(input2, 10);
            //PrintSubArrayWithGivenSum(input3, 10);
            //PrintSubArrayWithGivenSum(input4, 10);
            //PrintSubArrayWithGivenSum(input5, 10);


            var a = new int[] {5, 13, 6, 8, 10, 1};
            var result = GetSubArrayWithMaxSum_NoAdjacent_Elements(a);
            Console.WriteLine(result);

            Console.WriteLine(" Press enter key to exit.");
            Console.ReadLine();
        }
    }
}
