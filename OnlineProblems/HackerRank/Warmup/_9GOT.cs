using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    public class _9GOT
    {
        public static void Solution()
        {
            String S = Console.ReadLine();

            const int SIZE = 26;
            int[] a = new int[SIZE];
            int N = S.Length;

            for (int i = 0; i < N; i++)
            {
                a[S[i] - 'a']++;
            }

            var count = 0;
            for (int i = 0; i < SIZE; i++)
            {
                if (a[i] % 2 == 1)
                    count++;
                
                if (count > 1)
                    break;
            }

            if (count > 1)
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES");
        }
    }
}
