using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ************* IMPORTANT QUESTION ****************** //


namespace Algorithms.Problems.Recursion.subsets
{
    public class SubsetsProblem
    {
         /* How to handle duplicates? For example, if input array is {1, 2, 1} {1, 2} and {2, 1} as NOT two different combinations. 
            1) sort the array before calling printCombination()
            2) Add following lines at the end of for loop in combinationUtil()        
                while (arr[i] == arr[i+1])
                     i++; */

        // data[] holds the array that needs to be printed
        private void PrintCombination_Efficient(int[] arr, int n, int index, int i, int[] output)
        {
            if (i == n)
            {
                for (int j = 0; j < index; j++)
                    Console.Write(output[j]);
                Console.WriteLine();
                return;
            }

            output[index] = arr[i];
            
            // current is included, put next at next location
            PrintCombination_Efficient(arr, n, index+1, i+1, output);

            // current is excluded, replace it with next (Note that
            // i+1 is passed, but index is not changed)
            PrintCombination_Efficient(arr, n,   index, i+1, output);
        }

        private void PrintCombination(int[] arr, int start,int end, int index, int[] data)
        {
            if (start == arr.Length)
            {
                for (int j = 0; j < index; j++)
                    Console.Write(data[j]);
                Console.WriteLine();
                return;
            }

            for (int i = start; i <= end; i++)
            {
                data[index] = arr[i];
                // Print
                PrintCombination(arr, i+1, end, index+1, data);
            }
        }

        private void RecursivelyPrint_Jabez(List<int> A, ref List<int> B)
        {
            if (B.Count == 0)
            {
                A.ForEach(Console.Write);
                Console.WriteLine();

                B.Insert(0,A.Last());
                //A.RemoveAt(A.Count - 1);

                return;
            }

            int len = B.Count;
            for (var i = 0; i < len; i++)
            {
                List<int> tmp = new List<int>(A);
                tmp.Add(B[i]);

                for (int j = 0; j <= i; j++)
                    B.RemoveAt(0);
                RecursivelyPrint_Jabez(tmp, ref B);
            }

            A.ForEach(Console.Write);
            B.Insert(0, A.Last());
            Console.WriteLine();
        }

        private void RecursivelyPrint(List<int> A, List<int> B)
        {
            if (B.Count == 0)
            {
                A.ForEach(Console.Write);
                Console.WriteLine();
                return;
            }

            for (var i = 0; i < B.Count; i++)
            {
                List<int> tmp = new List<int>(A);
                tmp.Add(B[i]);

                List<int> tmp2 = new List<int>();
                for (var j = i+1; j <B.Count; j++)
                {
                    tmp2.Add(B[j]);
                }
                RecursivelyPrint(tmp, tmp2);
            }

            A.ForEach(Console.Write);
            Console.WriteLine();
        }

        // the totoal number of subsets is 2^N. SO use Bnary representatin for that
        private void PrintSubsets_UsingBinaryTrick(int[] A)
        {
            long count = (long) Math.Pow(2,A.Length);
            for (long i = 0; i < count; i++)
            {
                // Find all SET bits in i and Print only those numbers from A 
                int tmp = 0;
                while (tmp < A.Length)
                {
                    if ((i & 1 << tmp) != 0)
                    {
                        Console.Write(A[tmp]);
                    }
                    tmp++;
                }
                Console.WriteLine();
            }
        }
        
        public void Test()
        {
            int N = 4;
            int[] A = new int[N];
            for (int i = 1; i <= N; i++)
            {
                A[i-1] = i;
            }

            //var list = new List<int>(A);
            //RecursivelyPrint_Jabez(new List<int>(), ref list);

            //RecursivelyPrint(new List<int>(), new List<int>(A));
            //PrintSubsets_UsingBinaryTrick(A);
            
            int[] data = new int[A.Length];
            PrintCombination_Efficient(A, A.Length, 0, 0, data);

            
            //PrintCombination(A, 0, A.Length-1, 0, data);

            Console.ReadLine();
        }

    }
}
