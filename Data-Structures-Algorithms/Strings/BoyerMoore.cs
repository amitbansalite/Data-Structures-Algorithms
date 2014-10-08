using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.Strings
{
    public class BoyerMoore
    {
        private int[] ComputeShift(string pat, int M)
        {
            int[] a = new int[256];

            for (int i = 0; i < a.Length; i++)
                a[i] = -1;

            for (int i = 0; i < M; i++)
                a[pat[i]] = i;

            return a;
        }

        private void Search(string text, string pat)
        {
            int N = text.Length;
            int M = pat.Length;

            int[] a = ComputeShift(pat, M);

            int shift = 0;

            for (int i = 0; i < N; i+= shift)
            {
                shift = 0;
                int j = M -1 ;
                while ( j >= 0 )
                {
                    if (text[i + j] != pat[j])
                    {
                        shift = Math.Max(1, j - a[ text[j] ] );
                        break;
                    }
                    j--;
                }
                if (j == -1)
                {
                    Console.WriteLine("Pattern match found starting at index : {0}", i);
                    break;
                }
            }    
        }

        public void Test()
        {
            String text = "aabbathuykdababacwababcabababaaaa";
            string pat = "ababaca";

            Search(text, pat);

            Console.WriteLine("Press enter key to exit.");
            Console.ReadLine();
        }

    }
}
