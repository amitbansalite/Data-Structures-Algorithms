using System;

// pat : A B A B A C A
// a[] : 0 0 1 2 3 0 1
// a[i] contains the longest prefix that is also the suffix of the substring (0,i)

namespace Algorithms.Problems.Strings
{
    public class KMP
    {

        // a[i] = length of longes prefix of PATTERN which is a proper suffix of P[i]
        private int[] ComputePrefix(string pat, int M)
        {
            var a = new int[M];
            a[0] = 0;

            int i = 1;
            int k = 0;
            while(i < M)
            {
                if (pat[i] == pat[k])
                {
                    k++;
                    a[i] = k;
                    i++;
                }
                else
                {
                    if (k > 0)
                        k = a[k - 1];
                    else
                    {    a[i] = 0;
                        i++;
                    }
                }
            }
            return a;
        }

        private void KMPSearch(string text, string pat)
        {
            var N = text.Length;
            var M = pat.Length;
            var a = ComputePrefix(pat, M);

            int i = 0, j = 0;

            while (i < N)
            {
                if (text[i] == pat[j])
                {
                    j++;
                    i++;
                }
                if (j == M)
                {
                    Console.WriteLine(" Pattern matched in the Text starting at index : {0}", i-j);
                    break;
                    // If one needs to find all the pastterns, do not break and reset : j = a[j-1];
                }
                else if (text[i] != pat[j])
                {
                    if (j != 0)
                        j = a[j - 1];
                    else
                        i++;
                }
            }
        }

        public void Test()
        {
            String text = "aabbababacacacaaa";
            string pat = "abccba";
            
            //var prefix = ComputePrefix(pat);
            //for (var i = 0; i< prefix.Length; i++)
            //{
            //    Console.WriteLine(prefix[i]);
            //}

            KMPSearch(text, pat);

            Console.WriteLine("Press enter key to exit.");
            Console.ReadLine();
        }
    }
}
