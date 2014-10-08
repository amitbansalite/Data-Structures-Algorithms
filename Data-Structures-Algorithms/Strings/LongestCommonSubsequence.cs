using System;
using System.Collections.Generic;

// total time taken is O (N*N*N*M)
    // N*N*N to generate all possible sub strings of textA
    // M to find if the above sub string exists in the other textB

namespace Algorithms.Problems.Strings
{
    public class LongestCommonSubsequence
    {
        // returns the largest first then the smaller ones
        // time O(N*N*N)
        private IEnumerable<string> GetAllPermutations(string text)
        {
            int N = text.Length;

            // length of substring
            for (int i = N; i > 1; i--) 
            {
                // start index varies from (0, N-i]
                for (int j = 0; j <= N - i; j++)
                {
                    string current = text.Substring(j, i-1);
                    int lastChar = j + i - 1;
                    
                    // vary last index
                    for (int k = lastChar; k < N; k++)
                    {
                        yield return String.Concat(current, text[k]);
                    }
                }
            }
        }

        private void FindSmaller(string textA, string textB)
        {
            if (textA.Length < textB.Length)
                FindLongestSubString(textA, textB);
            else
                FindLongestSubString(textB, textA);
        }

        // smaller size is textA and lerger size is textB
        private void FindLongestSubString(string textA, string textB)
        {
            Console.WriteLine("text A : {0}", textA);
            Console.WriteLine("text B : {0}", textB);

            foreach (var str in GetAllPermutations(textA))
            {
                var match = Exists(str, textB);
                if (match)
                {
                    Console.WriteLine(" Longest subsequence that exists is {0} of length {1}", str, str.Length);
                    return;
                }
            }
            Console.WriteLine("There is no common subsequence.");
        }

        // find if textA exists in textB
        private bool Exists(string textA, string textB)
        {
            int N = textA.Length;
            int M = textB.Length;

            int j = 0;

            for (int i = 0; i < M; i++)
            {
                while (i < M && j < N && textA[j] != textB[i])
                    i++;

                if (j == N)
                    return true;
                j++;
            }
            return false;
        }



        public void Test()
        {
            // 1. Test GetAllPermutations()
            var textA = "XYFGH";
            var textB = "ABCHFHOFREHOREFHBOYEHGJCFWECJIEW";

            //foreach (var str in GetAllPermutations(text))
            //{
            //    Console.WriteLine(str);
            //}
            
            // 2. Test FindLongestSubString()
            FindSmaller(textA, textB);

            Console.WriteLine("\n\n Press enter to exit.");
            Console.ReadLine();
        }
    }
}
