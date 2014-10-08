using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    public class _6HalloweenParty
    {
        public static void Solution()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            
            ulong[] result = new ulong[N];
            for (int i = 0; i < N; i++)
            {
                ulong num = (ulong) Convert.ToInt64(Console.ReadLine());

                if ((num & 1) == 0)
                {
                    ulong cells = num/2;
                    result[i] = cells*cells;
                }
                else
                {
                    ulong cells = (num - 1)/2;
                    result[i] = cells*cells + cells;
                }
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
