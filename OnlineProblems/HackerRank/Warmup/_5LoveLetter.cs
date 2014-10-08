using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    public class _5LoveLetter
    {
        public static void Solution()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            
            int[] result = new int[N];
            for (int i = 0; i < N; i++)
            {
                String word = Console.ReadLine();
                int len = word.Length;

                int count = 0;
                for (int j = 0, k = len-1; j <= k ; j++, k--)
                {
                    if (word[j] != word[k])
                    {
                        count += Math.Abs(word[j] - word[k]);
                    }
                }
                result[i] = count;
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
