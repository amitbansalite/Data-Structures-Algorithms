using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    public class _8MaximisingXor
    {
        public static void Solution()
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            int max = 0;
            for (int i = a; i <= b; i++)
            {
                for (int j = a; j <= b; j++)
                {
                    int tmp = i ^ (j);
                    if (max < tmp)
                        max = tmp;
                }
            }

            Console.WriteLine(max);
        }
    }
}
