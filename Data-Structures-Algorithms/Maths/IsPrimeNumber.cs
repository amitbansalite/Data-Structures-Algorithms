using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.Maths
{
    public class IsPrimeNumber
    {
        private static void CalculatePrimes(bool[] primes, int range)
        {
            primes[0] = false;
            primes[1] = true;
            primes[2] = true;
            primes[3] = true;

            for (int i = 4; i < range; i++)
            {
                if ((i & 1) == 0)
                {
                    primes[i] = false;
                }
                else
                {
                    bool isPrime = true;
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (primes[j] && (i % j == 0))
                        {
                            primes[i] = false;
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                        primes[i] = true;
                }
            }
        }

        public void Test()
        {
            int range = 1000;
            bool[] primes = new bool[range];

            CalculatePrimes(primes, range);

            for (int i = 0; i < range; i++)
            {
                if (primes[i])
                    Console.WriteLine(i);
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
