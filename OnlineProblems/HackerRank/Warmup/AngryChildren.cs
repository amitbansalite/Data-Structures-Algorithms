using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    public class AngryChildren
    {
        public static void Solution()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int k = Convert.ToInt32(Console.ReadLine());
            var A = new int[N];

            for (int i = 0; i < N; i++)
            {
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            
            var result = GetUnfairnessValue(A, k);
            Console.WriteLine(result);
        }

        private static int GetUnfairnessValue(int[] A, int k)
        {
            Array.Sort(A);
            int globalDiff = A[k-1] - A[0];
            int loopCounter = A.Length - k;

            for (int i = 1; i <= loopCounter; i++)
            {
                int currDif = A[k++] - A[i];

                if (currDif < globalDiff)
                    globalDiff = currDif;
            }
            return globalDiff;
        }
    }
}
