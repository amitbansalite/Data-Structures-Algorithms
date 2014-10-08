using System;

// can be done without any loop at all


namespace Algorithms.Problems.HackerRank
{
    public class SherlockBeast
    {
        public static void Solution()
        {
            int T = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                int[] result = new int[N];

                if (N < 3)
                    Console.Write(-1);
                else if (N % 3 == 0)
                {
                    Print(5, N);
                }
                else
                {
                    int j = 1, tmp = N;
                    bool flag = false;

                    // j < 4 because maximu trailing 3's can be 0,5,10. and nothing else. (try it out with paper and pen)
                    while (j < 4 && tmp >= 3)
                    {
                        if ((tmp - 5) % 3 == 0)
                        {
                            flag = true;
                            Print(5, N - 5 * j);
                            Print(3, 5 * j);
                            break;
                        }
                        tmp = tmp - 5 * j;
                        j++;
                    }
                    if (!flag)
                        Console.Write(-1);
                }
                Console.WriteLine();
            }
        }

        private static void Print(int n, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(n);
            }
        }
    }
}
