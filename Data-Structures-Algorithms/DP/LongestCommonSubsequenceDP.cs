using System;

// O(N*M) time taken and O(N*M) time
// key is to identify the start position and the equation to update higher values

namespace Algorithms.Problems.DP
{
    public class LongestCommonSubsequenceDP
    {
         public int[][] FindSubSequence(string textA, string textB )
        {
	        int N = textA.Length;
	        int M = textB.Length;
	
	        int[][] dp = new int[N+1][];

             for (int i=0; i<=N; i++)
             {
                 dp[i] = new int[M+1];
             }

	        for(int i=0; i<=N; i++)
		        dp[i][0] = 0;
		
	        for(int i=0; i<=M; i++)
		        dp[0][i] = 0;
	
	        for(int i=1; i<=N; i++)
	        {
		        for(int j=1; j<=M; j++)
		        {
			        if ( textA[i-1] == textB[j-1])
				        dp[i][j] = dp[i-1][j-1] + 1;				
			        else
				        dp[i][j] = Math.Max(dp[i-1][j], dp[i][j-1]);
		        }
	        }
             return dp;
        }

        public char[] GetSubSequence(int[][] dp, string textA, string textB)
        {
            int N = textA.Length;
            int M = textB.Length;
            char[] lcs = new char[dp[N][M]];
            
            int k = lcs.Length - 1;
            int i = N;
            int j = M;

            while(i > 0)
            {
                while(j > 0)
                {
                    while ( j > 0 && dp[i][j-1] == dp[i][j])
                        j--;

                    while (i > 0 && dp[i - 1][j] == dp[i][j])
                        i--;

                    if (dp[i][j] > 0)
                    {
                        lcs[k--] = textA[i - 1];
                        i--;
                        j--;
                    }
                    if (k < 0)
                        return lcs;
                }
            }
            
            return lcs;
        }

        public void Test()
        {
            //var textA = "ABDBHCDRTWUNNGFREFN";
            //var textB = "CADMNHGTYIRN";

            //var textA = "BDCABA";
            //var textB = "ABCBDAB";

            var textA = "ABCBDAB";
            var textB = "BDCABA";
            
            var lcsMatrix = FindSubSequence(textA, textB);
            Console.WriteLine(" Longest sub sequence length {0} \n", lcsMatrix[textA.Length][textB.Length]);
            
            var lcs = GetSubSequence(lcsMatrix, textA, textB);
            Console.WriteLine(" The sub sequence is as follows : ");

            for (int i = 0; i < lcs.Length; i++)
            {
                Console.Write(lcs[i]);
            }

            Console.WriteLine("\n\n Press enter to exit.");
            Console.ReadLine();
        }
    }
}
