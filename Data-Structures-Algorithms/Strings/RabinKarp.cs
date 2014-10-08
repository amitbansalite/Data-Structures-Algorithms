
// based on modular hashing

// worst case is O(M*N)

// if checking for char to char match when hash mathces decreases performance even more (but guarantees right answer)

// Q should be suffieciently large prime number

using System;

namespace Algorithms.Problems.Strings
{
    public class RabinKarp
    {
        private long Q;          // prime number suffieciently large (M*N*N)
        private int R;          // base (for int 10, for characters either 26 or 256)
        private long RM;         // precompute value of R*(M-1)
        private long PatHash;    // hash value of the pattern
        private int M;          // length of the pattern

        public RabinKarp(string pat, int q, int r)
        {
            this.Q = q;
            this.R = r;
            this.M = pat.Length;
            PatHash = Hash(pat, M);
            
            RM = 1;
            for (int i = 1; i < M; i++)
                RM = (R * RM) % Q;
        }

        private long Hash(string input, int len)
        {
            long hash = 0;

            for (int i = 0; i < len; i++)
            {
                hash = (hash * R + input[i]) % Q;
            }
            return hash;
        }

        public int Search(string text)
        {
            int N = text.Length;
            long txtHash = Hash(text, M);

            if (PatHash == txtHash)
            {
                // To eliminate false +ves do a char by char match for text and pat when hash value matches
                return 0;
            }
            for (int i = M; i < N; i++)
            {
                txtHash = ( txtHash + Q -  (RM * text[i-M] % Q) )  % Q;
                txtHash = ( txtHash * R + text[i] ) % Q;

                if ( PatHash == txtHash)
                {
                    // To eliminate false +ves do a char by char match for text and pat when hash value matches
                    return i-M+1;
                }
            }
            return N;
        }

        public void Test()
        {
            var text = "AACDABACDABCD";
            var pat = "ABACD";
            var RK = new RabinKarp(pat, 997, 26);

            var result = RK.Search(text);

            if (result < text.Length)
                Console.WriteLine(" pat exists in the given text from position {0}", result);
            else
                Console.WriteLine(" pat does NOT exist in the given text.");

            Console.WriteLine(" Press enter to exit.");
            Console.ReadLine();
        }
    }
}
