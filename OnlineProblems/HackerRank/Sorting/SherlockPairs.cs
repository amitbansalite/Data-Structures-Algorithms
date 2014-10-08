using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank.Sorting
{
    public class SherlockPairs
    {
        public static void Solution()
        {
            int MAX = 1000000+1;
            int T = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                
                int[] dups = new int[MAX];

                String S = Console.ReadLine();
                String[] nums = S.Split(' ');
                for (int j = 0; j < N; j++)
                {
                    int num = Convert.ToInt32(nums[j]);
                    dups[num]++;
                }

                long count = 0;
                for (int j = 0; j < MAX; j++)
                {
                    int occurence = dups[j];
                    if (occurence > 1)
                        count += occurence * (long)(occurence-1);
                }
                Console.WriteLine( count );
            }
        }
    }
}
