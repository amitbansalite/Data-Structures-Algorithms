using System;

// ************ IMPORTANT ************** //

namespace Algorithms.Problems.Recursion.subsets
{
    public class PermutationsOfGivenString
    {
        // for ABC => A,B,C, AB, AC, BC, ABC
        private void PrintAllSubSequences(string prefix, string text)
        {
            int n = text.Length;
            if (n == 0) Console.WriteLine(prefix);
            else
            {
                PrintAllSubSequences(prefix + text[0], text.Substring(1));
                PrintAllSubSequences(prefix, text.Substring(1));
            }
        }

        // for ABC => ABC, ACB, BAC, BCA, CAB, CBC
        private void PrintPermutations(string prefix, string text)
        {
            int n = text.Length;
            if ( n == 0) Console.WriteLine(prefix);
            else
            {
                for (int i = 0; i < n; i++)
                {
                    PrintPermutations( prefix + text[i], 
                                       text.Substring(0,i) + text.Substring(i+1) );
                }
            }
        }

        public void Test()
        {
            var text = "ABCD";
            
            PrintPermutations("", text);
            Console.WriteLine("\n --------------- ");
            PrintAllSubSequences("", text);

            Console.WriteLine("\n\n Press enter to exit.");
            Console.ReadLine();
        }

    }
}
