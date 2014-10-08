using System;

namespace Algorithms.Problems.Strings
{
    public class LongestPalindromeSubString
    {
        // using Dynamic programing
        // maintain the max palindrome in all smaller sub strings and use that to calculate higher sub strings value
        // time : O (N * N) with space as (N * N)
        private void FindLongestPalDP(string text)
        {
            int startIndex = 0;
            int longestPal = 1;
            int N = text.Length;

            bool[,] dp = new bool[N,N];

            // all length 1 sub strings are palindromes
            for (int i = 0; i < N; i++)
            {
                dp[i, i] = true;
            }

            // all length 2 sub strings might be palindromes
            for (int i = 0; i < N-1; i++)
            {
                if (text[i] == text[i + 1])
                {
                    dp[i, i + 1] = true;
                    if (longestPal == 1)
                    {
                        longestPal = 2;
                        startIndex = i;
                    }
                }
            }

            // using the above values find for all other length sub strings
            // outer loop : sub stgring length
            // inner loop : to check for all continuous sub string of length i
            for (int i = 3; i <= N; i++)
            {
                for (int j = 0; j <= N-i; j++)
                {
                    int right = j+i-1;

                    if (text[j] == text[right] && dp[j + 1, right - 1])
                    {
                        dp[j, right] = true;
                        if (longestPal < i)
                        {
                            longestPal = i;
                            startIndex = j;
                        }
                    }
                }
            }

            Console.WriteLine("Longest palindrome in the given text {0} is of length {1}, starting at index {2}", text, longestPal, startIndex);
            Console.WriteLine("Sub string is : {0}", text.Substring(startIndex, longestPal));	
        }
        
        // better than DP as it takes O (N*N) with O(1) space
        // 1. check all centres for odd length string 
        // 2. check all centres for even length string
        private void FindLongestPal(string text)
        {
	        int startIndex = 0;
	        int longestPal = 1;
	        int N = text.Length;
	
	        // check for all odd length strings
	        for(int i =0; i < N; i++)
	        {
		        int left = i-1, right = i+1;
		        while (left >=0 && right < N && text[left] == text[right])
		        {
			        if ( (right - left + 1) > longestPal)
			        {
				        longestPal = right-left+1;
				        startIndex = left;
			        }
			        left--;
			        right++;		
		        }	
	        }
	
	        // check for all even length strings
	        for(int i =0; i < N-1; i++)
	        {
		        int left = i, right = i+1;		
		        while (left >=0 && right < N && text[left] == text[right])
		        {
			        if ( (right - left + 1) > longestPal)
			        {
				        longestPal = right-left+1;
				        startIndex = left;
			        }
			        left--;
			        right++;		
		        }	
	        }
	
	        Console.WriteLine("Longest palindrome in the given text {0} is of length {1}, starting at index {2}", text, longestPal, startIndex);
	        Console.WriteLine("Sub string is : {0}", text.Substring(startIndex, longestPal));	
        }
        
	    public void Test()
	    {
	        var text1 = "ABACCCCCBAAD";
	        var text2 = "forgeeksskeegfor";
	        var text3 = "babcbabcbaccba";
	        var text4 = "ABCDEFGH";
	        var text5 = "ABCDDCBA";
	        var text6 = "ABCDCBA";
	        var text7 = "AA";

            FindLongestPal(text7);
            Console.WriteLine("\n\n");
            FindLongestPalDP(text7);
            
            Console.WriteLine(" Press enter to exit.");
            Console.ReadLine();
	    }
    }
}
