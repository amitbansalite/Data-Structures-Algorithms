using System;

// ***** very very good questions **** //
    // hint : use a for loop inside the recursion

// print all possible words that can be formed given a telephone number of varying length

namespace Algorithms.Problems.Recursion
{
    public  class PrintWordsFromPhoneNumbers
    {
        private char[][] map;
        private int count = 0;

        public PrintWordsFromPhoneNumbers()
        {
            map = new char[10][];
            
            map[0] = new char[0];
            map[1] = new char[0];
            map[2] = new char[3]{'a', 'b', 'c'};
            map[3] = new char[3]{'d', 'e', 'f'};
            map[4] = new char[3]{'g', 'h', 'i'};
            map[5] = new char[3]{'j', 'k', 'l'};
            map[6] = new char[3]{'m', 'n', 'o'};
            map[7] = new char[4]{'p', 'q', 'r', 's'};
            map[8] = new char[3]{'t', 'u', 'v'};
            map[9] = new char[4]{'w', 'x', 'y', 'z'};
        } 

        private void Print(char[] result)
        {
            count++;
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]);
            }
            Console.WriteLine();
        }

        private void GetWords(int[] num, int curr, int len, char[] result)
        {
            if (curr == len)
            {
                Print(result);
                return;
            }

            if (num[curr] == 0 || num[curr] == 1)
                GetWords(num, curr + 1, len, result);

            for (int i = 0; i < map[num[curr]].Length; i++)
            {
                result[curr] = map[num[curr]][i]; 
                GetWords(num, curr+1, len, result);
            }
        }

        public void Test()
        {
            //int[] num = new int[8]{9, 2, 3, 4, 5, 6, 7, 8};
            int[] num = new int[2] { 2, 3};
            int len = num.Length;
            char[] result = new char[len];

            GetWords(num, 0, len, result);

            Console.WriteLine("Total words posible are {0} from given phone number of length {1}", count, len);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
