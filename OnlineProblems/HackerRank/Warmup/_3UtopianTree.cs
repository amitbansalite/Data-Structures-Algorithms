using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    class _3UtopianTree
    {
        public static void Solution()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            long[] result = new long[N];

            for (int i = 0; i < N; i++)
            {
                long height = 1;
                int cycles = Convert.ToInt32(Console.ReadLine());
                for (int j = 0; j < cycles; j++)
                {
                    height = (height & 1) == 0 ? height+1 : height<< 1;
                }
                result[i] = height;
            }
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
