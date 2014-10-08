using System;

/*                    1     1                               1     1     1
                      1     2                               1     1     2
                      1     3                               1     1     3
    N = 2             2     1           N = 3               1     2     1
    K = 3 ->          2     2           K = 3 ->                  …
                      2     3                               3     2     3
                      3     1                               3     3     1
                      3     2                               3     3     2
                      3     3                               3     3     3
 */

namespace Algorithms.Problems.Recursion
{
    public class PrintNumbers
    {
        public static int numberOfLoops;
        public static int numberOfIterations;
        public static int[] loops;

        public static void PrintLoops()
        {
            for ( int i = 0; i < numberOfLoops; i++)
                Console.Write("{0} ", loops[i]);
            Console.WriteLine();
        }

        /*public static void Main()
        {
            numberOfLoops = 5;
            numberOfIterations = 5;
            loops = new int[numberOfLoops];

            //Iterative_NestedLoops();
            Recursive_NestedLoops(0);

            Console.ReadLine();
        }*/

        #region Non recursive

        public static void InitLoops()
        {
            for (int i = 0; i < numberOfLoops; i++)
                loops[i] = 1;
        }

        public static void Iterative_NestedLoops()
        {
            InitLoops();

            while (true)
            {
                PrintLoops();
                int curPostion = numberOfLoops - 1;
                loops[curPostion] = loops[curPostion] + 1;

                while( (loops[curPostion] > numberOfIterations))
                {
                    loops[curPostion] = 1;
                    curPostion--;
                    if (curPostion < 0)
                        return;
                    loops[curPostion] = loops[curPostion] + 1;
                }
            }
        }
        #endregion

        #region recursive

        public static void Recursive_NestedLoops(int curPosition)
        {
            if (curPosition == numberOfLoops)
            {
                PrintLoops();
                return;
            }
            for (int i = 1; i <= numberOfIterations; i++)
            {
                loops[curPosition] = i;
                Recursive_NestedLoops(curPosition+1);
            }

        }
        #endregion
    }
}
