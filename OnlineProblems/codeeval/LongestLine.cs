using System;
using System.IO;
using System.Linq;

// constructing a MinPQ of length N

namespace Algorithms.Problems.codeeval
{
    public class LongestLine
    {
        public static void Test(String[] args)
        {
            var fileName = args[0];
            
            int lineNumber = 0;
            int i = 1;
            
            int N = 0;
            string[] pq = null;

            using (StreamReader reader = File.OpenText(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (lineNumber == 0)
                    {
                        N = Convert.ToInt32(line);
                        pq = new string[N+1];
                    }

                    else if (line != null)
                    {
                        line = line.Trim();
                        if (line.Any())
                        {
                            if (i <= N)
                            {
                                pq[i++] = line;
                            }
                            else
                            {
                                if (pq[1].Length < line.Length)
                                {
                                    pq[1] = line;
                                    Sink(pq, 1, N);
                                }
                            }
                        }
                    }
                    lineNumber++;
                    if (i > N)
                    {
                        for (int j = N/ 2; j >= 1; j--)
                        {
                            Sink(pq, j, N);
                        }
                    }
                }
            }
            
            // display this is desc order
            int tmp = N;
            while (tmp>1)
            {
                exch(pq, 1, tmp--);
                Sink(pq, 1,tmp);
            }

            for (int j = 1; j <= N; j++)
                Console.WriteLine(pq[j]);
        }

        private static void Sink(string[] pq, int pos, int N)
        {
            while (2*pos <= N)
            {
                int j = 2*pos;

                if (j<N && less(pq, j+1, j))
                    j++;

                if (less(pq, pos, j))
                    break;
                
                exch(pq, pos, j);
                pos = j;
            }
        }

        private static bool less(string[] pq, int p, int q)
        {
            return pq[p].Length < pq[q].Length;
        }

        private static void exch(string[] pq, int p, int q)
        {
            var tmp = pq[p];
            pq[p] = pq[q];
            pq[q] = tmp;
        }
    }
}
