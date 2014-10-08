using System;
using System.Text;
using Algorithms.Problems.DP;

namespace Algorithms.Problems.Strings
{
    public class SmallestSuperSequence
    {
        private char[] FindSuperSequence(string textA, string textB, char[] lcs)
        {
            int N = textA.Length;
            int M = textB.Length;
            int R = lcs.Length;

            char[] scs = new char[M + N - R];
            // M + N = R + Z    (Z stands for the length of smallest common sequence)
            
            for (int i = 0; i < R; i++)
                scs[i] = lcs[i];

            for (int i = 0; i < N; i++)
            {
                if (textA[i] != scs[i])
                {
                    // insert textA[i] at ith position in scs and move all it ahead by 1 character
                    InsertChar(scs, textA[i], i);
                }
            }

            for (int i = 0; i < M; i++)
            {
                if (textB[i] != scs[i])
                {
                    // insert textB[i] at ith position in scs and move all it ahead by 1 character
                    InsertChar(scs, textB[i], i);
                }
            }
            return scs;
        }

        private void InsertChar(char[] scs, char insert, int position)
        {
            char replace = scs[position];
            scs[position] = insert;
            
            for (int i = position+1; i < scs.Length-1; i++)
            {
                char tmp = scs[i];
                scs[i + 1] = replace;
                replace = tmp;
            }
        }


        public void Test()
        {
            var textA = "BDCABA";
            var textB = "ABCBDAB";

            var obj = new LongestCommonSubsequenceDP();

            var lcsMatrix = obj.FindSubSequence(textA, textB);
            Console.WriteLine(" Longest sub sequence length {0} \n", lcsMatrix[textA.Length][textB.Length]);

            var lcs = obj.GetSubSequence(lcsMatrix, textA, textB);
            Console.WriteLine(" The sub sequence is as follows : ");

            for (int i = 0; i < lcs.Length; i++)
            {
                Console.Write(lcs[i]);
            }

            // TODO : not working
            var scs = FindSuperSequence(textA, textB, lcs);

            Console.WriteLine("\n The super sequence is as follows. ");
            foreach (var ch in scs)
            {
                Console.Write(ch);
            }

            Console.WriteLine("\n\n Press enter to exit.");
            Console.ReadLine();
        }
    }
}
