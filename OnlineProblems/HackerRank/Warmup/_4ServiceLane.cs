using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    public class _4ServiceLane
    {
        public static void Solution()
        {
            String input = Console.ReadLine();
            string[] s = input.Split(' ');
            int N = Convert.ToInt32(s[0]);
            int T = Convert.ToInt32(s[1]);

            int[] width = new int[N];
            string wid = Console.ReadLine();
            String[] w = wid.Split(' ');
            for (int i = 0; i < N; i++)
            {
                width[i] = Convert.ToInt32(w[i]);
            }

            int[] result = new int[T];
            for (int i = 0; i < T; i++)
            {
                String inp = Console.ReadLine();
                string[] e = inp.Split(' ');
                int entry = Convert.ToInt32(e[0]);
                int exit = Convert.ToInt32(e[1]);

                int min = 4;
                for (int j = entry; j <= exit; j++)
                {
                    if (width[j] < min)
                        min = width[j];
                    if ( min == 1)
                        break;
                }
                result[i] = min;
            }

            for (int i = 0; i < T; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
