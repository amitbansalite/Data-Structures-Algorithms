using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    public class SherlockSquares
    {
        public static void Solution()
        {
            int MAX = 1000000000;
            int T = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                String s = Console.ReadLine();
                string[] str = s.Split(' ');

                int a = Convert.ToInt32(str[0]);
                int b = Convert.ToInt32(str[1]);

                double start = Math.Sqrt(a);
                double end = Math.Sqrt(b);
                int count;

                if (start%1 == 0 || end%1 == 0)
                    count = (int)(end - start) + 1;
                else
                    count = (int)end - (int)start;

                Console.WriteLine(count);
            }
        }
    }
}
