using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank.Sorting
{
    public class Crush
    {
        public static void Solution()
        {
            //Naive();

            SuperCool();
        }

        private static void Naive()
        {
            String S = Console.ReadLine();
            String[] nums = S.Split(' ');

            int N = Convert.ToInt32(nums[0]);
            int M = Convert.ToInt32(nums[1]);

            long max = 0;
            long[] total = new long[N];

            for (int i = 0; i < M; i++)
            {
                S = Console.ReadLine();
                nums = S.Split(' ');

                int a = Convert.ToInt32(nums[0]);
                int b = Convert.ToInt32(nums[1]);
                long k = Convert.ToInt32(nums[2]);

                for (int j = a - 1; j < b; j++)
                {
                    total[j] += k;
                    if (total[j] > max)
                        max = total[j];
                }
            }
            Console.WriteLine(max);
        }

        private static void SuperCool()
        {
            String S = Console.ReadLine();
            String[] nums = S.Split(' ');

            int N = Convert.ToInt32(nums[0]);
            int M = Convert.ToInt32(nums[1]);

            long[] total = new long[N+1];

            for (int i = 0; i < M; i++)
            {
                S = Console.ReadLine();
                nums = S.Split(' ');

                int a = Convert.ToInt32(nums[0]);
                int b = Convert.ToInt32(nums[1]);
                long k = Convert.ToInt32(nums[2]);

                total[a - 1] += k;
                total[b] -= k;
            }

            long max = 0;
            long current = 0;
            for (int i = 0; i < N; i++)
            {
                current += total[i];
                if (current > max)
                    max = current;
            }
            Console.WriteLine(max);
        }
    }
}
