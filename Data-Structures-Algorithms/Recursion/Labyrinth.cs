using System;

namespace Algorithms.Problems.Recursion
{
    // grid with values 
        // [i,j] = 0 is passable 
        // [i,j] = 1 is not passable
        // [i.j] = 2 is currently visited

    // print all possible paths

    public class Labyrinth
    {
        public static int[,] Grid;
        public static int N = 4;
        
        public static int[] Path;
        public static int count;
        public static int totalPaths;

        /*public static void Main()
        {
            Grid = new int[N,N];

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    Grid[i,j] = 0;

            Grid[1,1] = 1;
            Grid[2, 2] = 1;
            Grid[3, 2] = 1;

            Path = new int[N*N];

            count = 0;
            totalPaths = 0;

            FindPaths(0,0);

            if ( totalPaths == 0)
                Console.WriteLine("No paths found");
            else
                Console.WriteLine("{0} possible paths found", totalPaths);

            Console.ReadLine();
        }*/

        public static void FindPaths(int row, int col)
        {
            // boundary condition checking
            if (row < 0 || col < 0 || row >= N || col >= N)
                return;

            // not passable or already visited
            if (Grid[row,col] == 1 || Grid[row,col] == 2)
                return;

            // path found !!! hurrary :)
            if (row == N - 1 && col == N - 1)
            {
                PrintPath();
                return;
            }

            // add current node to path array 
            Path[count] = row * N + col;
            count++;
            
            if (Grid[row, col] == 0)
            {
                Grid[row, col] = 2; // [i;j] = 2 means already visited

                FindPaths(row + 1, col);
                FindPaths(row - 1, col);
                FindPaths(row, col + 1);
                FindPaths(row, col - 1);

                Grid[row, col] = 0;   
            }

            count--;
            Path[count] = 0;
        }   

        public static void PrintPath()
        {
            totalPaths++;
            Console.Write("{0} steps required : ", count+1);
            Console.Write("{0} ", Path[0]);
            int i = 1;

            while( Path[i] !=0)
            {
                Console.Write("{0} ", Path[i]);
                i++;
            }

            Console.Write(N*N-1);

            Console.WriteLine();
        }
    }
}
