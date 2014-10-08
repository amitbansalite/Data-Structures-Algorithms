using System;

namespace Algorithms.Problems.Arrays
{
    public class LargestSumSubArray
    {
        // can contain -ve values also
        private void FindSubArrayWithMaxSum(int[] a)
        {
            int currSum = 0, globalSum = 0;
            int startIndex = -1, globalStartIndex = -1, endIndex = -1;

            
            for (int i = 0; i < a.Length-1; i++)
            {
                currSum = currSum + a[i];

                if (currSum < 0)
                {
                    currSum = 0;
                    startIndex = -1;
                }
                else
                {
                    if (startIndex < 0)
                        startIndex = i;
                    if (globalSum < currSum)
                    {
                        globalSum = currSum;
                        if (globalStartIndex < 0)
                            globalStartIndex = startIndex;
                        else
                            endIndex = i;
                    }    
                }
            }
            if (globalSum > 0)
            {
                Console.WriteLine("{0} : {1}", globalStartIndex, endIndex);
                Console.WriteLine(globalSum);
            }
        }
        
        // Only +ve integers allowed 
        private void FindSubArrayWithGivenSum(int input, int[] a)
        {
            int currSum = a[0];
            int startIndex = 0;
            bool found = false;

            for (int i = 1; i < a.Length - 1; i++)
            {
                if (currSum > input && startIndex < i-1)
                {
                    currSum = currSum - a[startIndex++];
                }
                if ( currSum == input)
                {
                    Console.WriteLine("{0} : {1}", startIndex, i-1);
                    found = true;
                    break;
                }

                currSum = currSum + a[i];
            }
            if ( !found)
                Console.WriteLine("Cannot find any sub array which sums upto given value : {0}", input);
        }

        // approach : try to minimize (curr sum - input)
        private void FindSubArrayWithClosestSum(int[] a, int input)
        {
            int currSum = a[0];
            int startIndex = 0;
            int currDiff = Math.Abs(currSum-input);

            int minDiff = currDiff, bestStart = 0, bestEnd=-1;

            for (int i = 1; i < a.Length - 1; i++)
            {
                currSum = a[i] + currSum;
                currDiff = Math.Abs(currSum - input);

                    while (currDiff > minDiff && startIndex < i)
                    {
                        currSum = currSum - a[startIndex++];
                        currDiff = Math.Abs(currSum - input);
                    }
                    if (currDiff < minDiff)
                    {
                        minDiff = currDiff;
                        bestEnd = i;
                        bestStart = startIndex;
                    }
            }
            Console.WriteLine(" {0} : {1} : {2}", bestStart, bestEnd, input);
        }

        public void Test()
        {
            //int[] a = new int[8] { -2, -3, 4, -1, -2, 1, 5, -3 };
           
            //FindSubArrayWithMaxSum(a);

            //int[] a = new int[6]{1, 4, 20, 3, 10, 5};
            
            //FindSubArrayWithGivenSum(24, a);

            int[] a = new int[6]{1, 4, 20, 3, 10, 5};

            FindSubArrayWithClosestSum(a, 31);

            Console.ReadLine();
        }
    }
}
