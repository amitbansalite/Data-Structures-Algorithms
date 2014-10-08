using System;

namespace Algorithms.Problems.Arrays
{
    public class RotateArray
    {
        //k lies between 0 and N-1
        private void Rotate(int[] a, int k)
        {
            int count = 0;
            int curIndex = 0, curValue = a[0];
            int destIndex = 0;
            int N = a.Length;

            while (count < N)
            {
                count++;

                if (curIndex + k < N)
                    destIndex = curIndex + k;
                else
                    destIndex = curIndex + k - N;

                int tmp = a[destIndex];
                a[destIndex] = curValue;
                curValue = tmp;
                curIndex = destIndex;
            }
        }

        private void Rotate_Efficient()
        {
            
        }

        public void Test()
        {
            var arr = new int[7] { 1, 2, 3 , 4, 5, 6, 7};
            
            Rotate(arr, 0);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" {0} ", arr[i]);
            }
            
            Console.WriteLine("\n Press enter key to exit.");
            Console.ReadLine();
        }
    }
}
