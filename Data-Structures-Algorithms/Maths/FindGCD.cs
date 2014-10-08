using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ************ GCD ************

// remember that GCD (a,b,c) = GCD ( GCD(a,b) , c) and so on and so forth

// also remember that if GCD (a,b) = 1 then GCD (a, b, c,d,.. N) = 1


namespace Algorithms.Problems.Maths
{
    public class FindGCD
    {
        // http://en.wikipedia.org/wiki/Greatest_common_divisor#Using_Euclid.27s_algorithm
        private int GetGCD(int a, int b)
        {
            if (a%b == 0)
                return b;
            else
                return GetGCD(b, a%b);
        }

        // http://en.wikipedia.org/wiki/Greatest_common_divisor#Binary_method
        private int GetGCD_Binary(int a, int b, int d)
        {
            if (a == b)
                return a * d;
            if (b == 0)
                return a * d;
            if (a == 0)
                return b * d;

            if (a % 2 == 0 && b % 2 == 0)
                return GetGCD_Binary(a >> 1, b >> 1, d + 1);
            if (a % 2 == 0)
                return GetGCD_Binary(a >> 1, b, d);
            if (b % 2 == 0)
                return GetGCD_Binary(a, b >> 1, d);
            if (a > b)
                return GetGCD_Binary((a - b) >> 1, b, d);

            return GetGCD_Binary((b - a) >> 1, a, d);
        }

        public void Test()
        {
            int a = 30;
            int b = 12;

            var result = GetGCD(a, b);
            Console.WriteLine(result);

            result = GetGCD_Binary(a, b, 1);
            Console.WriteLine(result);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}

