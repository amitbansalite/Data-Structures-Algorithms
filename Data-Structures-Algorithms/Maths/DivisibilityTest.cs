using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.Maths
{
    public class DivisibilityTest
    {
        public void Test()
        {
            int n = 707783;
            Console.WriteLine(" {0} is divisible by 7 : {1}", n, IsDivisibleBy7(n));

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }



        private bool IsDivisibleBy2(long n)
        {
            return (n & 1) == 0;
        }

        private bool IsDivisibleBy3(long n)
        {
            long sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n = n / 10;
            }
            return (sum % 3) == 0;
        }

        private bool IsDivisibleBy4(long n)
        {
            long last2Digits = n % 100;

            return (last2Digits % 4) == 0;
        }

        private bool IsDivisibleBy5(long n)
        {
            long lastDigit = n % 10;
            return lastDigit == 0 || lastDigit == 5;
        }

        private bool IsDivisibleBy6(long n)
        {
            return IsDivisibleBy2(n) && IsDivisibleBy3(n);
        }

        // ******** IMPORTANT ****** difficult to remember
        private bool IsDivisibleBy7(long n)
        {
            long remaining = n;

            while (remaining >= 10)
            {
                long lastDigit = remaining % 10;
                long rest = remaining / 10;
                remaining = rest - (lastDigit << 1);
            }
            if (remaining == 0 || remaining % 7 == 0)
                return true;

            return false;
        }

        // ******** dificult to remember **********
        private bool IsDivisibleBy8(long n)
        {
            long rem = n % 1000;
            return (rem % 8) == 0;
        }

        private bool IsDivisibleBy9(long n)
        {
            long sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n = n / 10;
            }
            return (sum % 9) == 0;
        }
    }
}
