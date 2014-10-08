using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    public class FillingJars
    {
        public static void Solution()
        {
            String inp = Console.ReadLine();
            String[] s = inp.Split(' ');

            int N = Convert.ToInt32(s[0]);
            int M = Convert.ToInt32(s[1]);

            long totalSum = 0;

            for (int i = 0; i < M; i++)
            {
                String val = Console.ReadLine();
                String[] v = val.Split(' ');

                int a = Convert.ToInt32(v[0]);
                int b = Convert.ToInt32(v[1]);
                int k = Convert.ToInt32(v[2]);

                totalSum += ((b - a + 1)* (long) k); 
            }

            double result = totalSum / N;
            long avg = (long)Math.Floor(result);
            Console.WriteLine(avg);
        }
    }
}
