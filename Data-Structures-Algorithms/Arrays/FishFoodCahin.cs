using System;
using System.Collections.Generic;

namespace Algorithms.Problems.Arrays
{
    public class FishFoodCahin
    {
        private int GetFishAliveCount(int[] A, int[] B)
        {
            int count = 0;
            Stack<int> downFish = new Stack<int>();
            
            for (int j = 0; j < A.Length; j++)
            {
                if (B[j] == 0 && downFish.Count == 0)
                    count++;
                else if (B[j] == 1)
                    downFish.Push(j);
                else
                {
                    while (downFish.Count != 0 && A[downFish.Peek()] < A[j])
                    {
                        downFish.Pop();
                    }
                    if (downFish.Count == 0)
                        count++;
                }
            }
            
            return count + downFish.Count;
        }

        public void Test()
        {
            int[] a = { 4, 3, 2, 1, 5 };
            int[] b = { 0, 1, 0, 0, 0 };
            
            Console.WriteLine(2 == GetFishAliveCount(a, b));

            a = new int[] { 4, 3, 2, 1, 5 };
            b = new int[] { 0, 1, 0, 1, 0 };
            Console.WriteLine(2 == GetFishAliveCount(a, b));

            a = new int[] { 4, 3, 2, 1, 5 };
            b = new int[] { 0, 0, 0, 0, 0 };
            Console.WriteLine(5 == GetFishAliveCount(a, b));

            a = new int[] { 4, 3, 2, 1, 5 };
            b = new int[] { 1, 1, 1, 1, 1 };
            Console.WriteLine(5 == GetFishAliveCount(a, b));

            a = new int[] { 4, 3, 2, 1, 5 };
            b = new int[] { 0, 0, 0, 1, 1 };
            Console.WriteLine(5 == GetFishAliveCount(a, b));

            a = new int[] { 5, 3, 2, 1, 4 };
            b = new int[] { 1, 0, 0, 0, 0 };
            Console.WriteLine(1 == GetFishAliveCount(a, b));

            a = new int[] { 1, 2, 3, 4, 5 };
            b = new int[] { 1, 1, 1, 1, 0 };
            Console.WriteLine(1 == GetFishAliveCount(a, b));

            Console.WriteLine("\n Press enter key to exit.");
            Console.ReadLine();
        }

    }
}
