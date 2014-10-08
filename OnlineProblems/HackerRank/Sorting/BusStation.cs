using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank.Sorting
{
    public class BusStation
    {
        public static void Solution()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int[] A = new int[N];

            String S = Console.ReadLine();
            String[] nums = S.Split(' ');

            int max = 0, sum = 0;

            for (int j = 0; j < N; j++)
            {
                A[j] = Convert.ToInt32(nums[j]);
                sum += A[j];
                if (A[j] > max)
                    max = A[j];
            }

            var result = new List<int>();
            for (int i = max; i <= sum/2; i++)
            {
                if (sum%i == 0)
                {
                    int j = 0;
                    while (j < N)
                    {
                        int busCapacity = i;
                        while (busCapacity > 0)
                        {
                            busCapacity = busCapacity - A[j];
                            j++;
                        }
                        if ( busCapacity != 0)
                            break;
                    }
                    if (j == N)
                        result.Add(i);
                }
            }

            foreach (int t in result)
            {
                Console.Write("{0} ", t);
            }
            Console.Write("{0}", sum);
        }
    }
}
