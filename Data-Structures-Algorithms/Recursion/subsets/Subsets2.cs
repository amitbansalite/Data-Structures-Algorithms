using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://www.geeksforgeeks.org/print-all-possible-combinations-of-r-elements-in-a-given-array-of-size-n/

namespace Algorithms.Problems.Recursion.subsets
{
    public class Subsets2
    {
        private void Print(List<int> ToPrint, List<int> A, int len)
        {
            if (ToPrint.Count == len)
            {
                for (int i=0; i<ToPrint.Count; i++)
                {
                    Console.Write(ToPrint[i]);
                }

                Console.WriteLine();
                return;
            }

            for (int i = 0; i < A.Count; i++)
            {
                var tmp = new List<int>(ToPrint);
                tmp.Add(A[i]);

                var tmp2 = new List<int>();
                for (int j = i+1; j < A.Count; j++)
                    tmp2.Add(A[j]);

                Print(tmp, tmp2, len);
            }
        }

        public void Test()
        {
            int len = 3;

            int[] A = new int[] {1,2,3,4,5,6};
            var B = new List<int>();
            Print(B, A.ToList(), len);

            Console.ReadLine();        
        }
    }
}
