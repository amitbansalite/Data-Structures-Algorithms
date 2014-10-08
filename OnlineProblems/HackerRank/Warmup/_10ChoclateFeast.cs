using System;

namespace Algorithms.Problems.HackerRank.Warmup
{
    public class _10ChoclateFeast
    {
        public static void Solution()
        {
            int T = Convert.ToInt32(Console.ReadLine());
             
            int[] result = new int[T];
            for(int i=0; i < T; i++)
            {
                String S = Console.ReadLine();
                string[] nums = S.Split(' ');
                
                int N = Convert.ToInt32(nums[0]);
                int C = Convert.ToInt32(nums[1]);
                int M = Convert.ToInt32(nums[2]);

                int totalCount = 0;
                int currCount = N/C;
                totalCount += currCount;
                
                while (currCount >= M)
                {
                    int tmp = currCount/M;
                    totalCount += tmp;
                    currCount = (currCount/M) + (currCount%M);
                }
                result[i] = totalCount;
            }
            for (int i = 0; i < T; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
