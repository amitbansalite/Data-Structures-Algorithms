using System;

namespace Algorithms.Problems.HackerRank
{
    public class _1GenStones
    {
        public static void Solution()
        {
            string num = Console.ReadLine();
            int N = int.Parse(num);

            int[] gems = new int[26];

            for (int i = 0; i < N; i++)
            {
                string composition = Console.ReadLine();
                for (int j = 0; j < composition.Length; j++)
                {
                    int index = composition[j] - 'a';
                    if (gems[index] == i)
                        gems[index]++;

                }
            }

            int count = 0;
            for (int i = 0; i < 26; i++)
            {
                if (gems[i] == N)
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}
