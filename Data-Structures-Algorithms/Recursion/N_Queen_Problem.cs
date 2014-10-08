namespace Algorithms.Problems.Recursion
{
    public class N_Queen_Problem
    {
        public static int N;
        public static int[,] Grid;
        public static int count;

        //public static void Main()
        //{
        //    N = 16;
        //    Grid = new int[N, N];
        //    count = 0;

        //    //Console.WriteLine(Grid.Length);

        //    PlaceQueens(0, 0);

        //    Console.WriteLine("There are {0} number of ways to place {1}  queens in a [{1},{1}] grid", count, N);

        //    Console.ReadLine();
        //}

        public static void PlaceQueens(int row, int counter)
        {   
            for (int i = 0; i < N; i++)
            {
                if (isSafe(row, i))
                {
                    Grid[row, i] = 1;
                    counter++;

                    if (counter == N)
                    {
                        PrintQueens();
                        return;
                    }
        
                    PlaceQueens(row+1, counter);

                    Grid[row, i] = 0;
                    counter--;
                }
            }
        }

        private static bool isSafe(int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (Grid[i, col] == 1)
                    return false;
            }
             
            // left upper diagonal
            int x = row-1;
            int y = col-1;
            while (x >= 0 && y >= 0)
            {
                if (Grid[x--, y--] == 1)
                    return false;
            }

            // right upper diagonal
            x = row-1;
            y = col+1;
            while (x >= 0 && y < N)
            {
                if (Grid[x--, y++] == 1)
                    return false;
            }
            return true;
        }

        public static void PrintQueens()
        {
            count++;
            //for (int i = 0; i < N; i++)
            //{
            //    for (int j = 0; j < N; j++)
            //    {
            //        Console.Write("{0} ", Grid[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
        }
    }
}
