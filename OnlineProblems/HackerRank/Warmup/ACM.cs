using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.HackerRank
{
    public class ACM
    {
        public static void Solution()
        {
            String input = Console.ReadLine();
            String[] i = input.Split(' ');

            int N = Convert.ToInt32(i[0]);
            int M = Convert.ToInt32(i[1]);
            
            var topics = new bool[N][];

            for (int j = 0; j < N; j++)
            {
                String bits = Console.ReadLine();
                topics[j] = new bool[M];

                for (int k = 0; k < M; k++)
                {
                    bool value = bits[k] == '1';
                    topics[j][k] = value;
                }
            }

            int maxTopics = 0;
            int teamCount = 0;

            for (int j = 0; j < N-1; j++)
            {
                for (int k = j+1; k < N; k++)
                {
                    var countOfSetBits = GetTopicsKnown(topics[j], topics[k]);

                    if (maxTopics < countOfSetBits)
                    {
                        maxTopics = countOfSetBits;
                        teamCount = 1;
                    }
                    else if (maxTopics == countOfSetBits)
                    {
                        teamCount++;
                    }
                }
            }

            Console.WriteLine(maxTopics);
            Console.WriteLine(teamCount);
        }

        private static int GetTopicsKnown(bool[] a, bool[] b)
        {
            int count = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (a[i] || b[i])
                    count++;
            }
            return count;
        }
    }
}
