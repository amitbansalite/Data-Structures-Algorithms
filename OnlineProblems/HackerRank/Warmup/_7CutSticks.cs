using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    public class _7CutSticks
    {
        public static void Solution()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            
            String lengths = Console.ReadLine();
            String[] len = lengths.Split(' ');

            int[] nums = new int[N];

            for (int i = 0; i < len.Length; i++)
            {
                nums[i] = Convert.ToInt32(len[i]);
            }

            Array.Sort(nums);

            int[] result = new int[N];
            result[0] = N;

            int j = 0, k = 0;
            int count = 1;

            while (j < N-1)
            {
                if ( j+1 < N && nums[j] == nums[j+1])
                {   
                    count = count+1;
                }
                else
                {
                    result[k+1] = result[k] - count;
                    k++;
                    count = 1;
                }
                j++;
            }

            for (int i = 0; i < N; i++)
            {
                if ( result[i] == 0)
                    break;
                Console.WriteLine(result[i]);
            }
        }

        public void PrintUniqueElementsWithCount()
        {
            int[] A = new int[] { 2, 2, 3, 3, 3, 4, 4, 5, 5, 5, 5, 6, 7, 8, 9, 9, 9, 9, 9, 9};

            int i = 0;
            int count = 1;

            while (i < A.Length)
            {
                if (i + 1 < A.Length && A[i] == A[i + 1])
                    count++;
                else
                {
                    Console.WriteLine("{0} : {1}", A[i], count );
                    count = 1;
                }
                i++;
            }
            
        }
    }
}
