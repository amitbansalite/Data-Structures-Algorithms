using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.Maths
{
    public class IsPerfectSquare
    {
        public void Test()
        {
            int N = Convert.ToInt32(Console.ReadLine());

            double root = Math.Sqrt(N);

            bool result = (root % 1) == 0;

            Console.WriteLine(result);
        }
    }
}
