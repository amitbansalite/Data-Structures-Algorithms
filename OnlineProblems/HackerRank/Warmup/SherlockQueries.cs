using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Really cool multiplication question

namespace Algorithms.Problems.HackerRank
{
    public class SherlockQueries
    {
        public static void Solution()
        {
            String nums = Console.ReadLine();
            String[] s = nums.Split(' ');

            int N = Convert.ToInt32(s[0]);
            int M = Convert.ToInt32(s[1]);

            long[] A = new long[N + 1];
            long[] B = new long[M + 1];
            long[] C = new long[M + 1];
            
            nums = Console.ReadLine();
            s = nums.Split(' ');
            for (int i = 1; i <= N; i++)
            {
                A[i] = Convert.ToInt32(s[i-1]);
            }

            nums = Console.ReadLine();
            s = nums.Split(' ');
            for (int i = 1; i <= M; i++)
            {
                B[i] = Convert.ToInt32(s[i-1]);
            }
            
            nums = Console.ReadLine();
            s = nums.Split(' ');
            for (int i = 1; i <= M; i++)
            {
                C[i] = Convert.ToInt32(s[i-1]);
            }

            Multiply(A, B, C, N, M);

            for (int i = 1; i <= N; i++)
            {
                Console.Write("{0} ", A[i] );
            }
        }

        private static void Calculate(long[] A, long[] B, long[] C, int N, int M)
        {
            for (int i = 1; i <= M; i++)
            {
                int inc = 2;
                long j = B[i];
                while (j <= N)
                {
                    A[j] = (A[j] * C[i]) % 1000000007;
                    j = B[i] * inc++;
                }
            }
        }

        private static void Multiply(long[] A, long[] B, long[] C, int N, int M)
        {   
            long[] counti = new long[100000+1];
            for (int i = 0; i <= 100000; i++)
            {
                counti[i] = -1;
            }

            for (int i = 1; i <= M; i++)
            {
                if (counti[B[i]] == -1)
                    counti[B[i]] = C[i];
                else
                    counti[B[i]] = (counti[B[i]] * C[i]) % 1000000007; 
            }
            
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; i*j <= N; j++)
                {
                    if (counti[i] != -1)
                        A[j*i] = (A[j*i] * counti[i]) % 1000000007;
                }
            }
        }
    }
}
