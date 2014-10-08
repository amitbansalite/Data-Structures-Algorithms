using System;

namespace Algorithms.Problems.HackerRank
{
    public class FindDigits
    {
        public static void Solution()
        {
            int T = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                long N = Convert.ToInt64(Console.ReadLine());
                int count = 0;

                long tmp = N;
                while (tmp > 0)
                {
                    switch (tmp%10)
                    {
                        case 0 : 
                            break;
                        case 1:
                            count++;
                            break;
                        case 2 :
                            if (IsDivisibleBy2(N))
                                count++;
                            break;
                        case 3:
                            if (IsDivisibleBy3(N))
                                count++;
                            break;
                        case 4:
                            if (IsDivisibleBy4(N))
                                count++;
                            break;
                        case 5:
                            if (IsDivisibleBy5(N))
                                count++;
                            break;
                        case 6:
                            if (IsDivisibleBy6(N))
                                count++;
                            break;
                        case 7:
                            if (IsDivisibleBy7(N))
                                count++;
                            break;
                        case 8:
                            if (IsDivisibleBy8(N))
                                count++;
                            break;
                        case 9:
                            if (IsDivisibleBy9(N))
                                count++;
                            break;
                    }
                    tmp = tmp/10;
                }
                Console.WriteLine(count);
            }
        }

        private static bool IsDivisibleBy2(long n)
        {
            return (n&1) == 0;
        }

        private static bool IsDivisibleBy3(long n)
        {
            long sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n = n / 10;
            }
            return (sum%3) == 0;
        }

        private static bool IsDivisibleBy4(long n)
        {
            long last2Digits = n%100;

            return (last2Digits % 4) == 0;
        }

        private static bool IsDivisibleBy5(long n)
        {
            long lastDigit = n%10;
            return lastDigit == 0 || lastDigit == 5;
        }

        private static bool IsDivisibleBy6(long n)
        {
            return IsDivisibleBy2(n) && IsDivisibleBy3(n);
        }

        // ******** IMPORTANT ****** difficult to remember
        private static bool IsDivisibleBy7(long n)
        {
            long remaining = n;

            while (remaining >=10)
            {
                long lastDigit = remaining % 10;
                long rest = remaining / 10;
                remaining = rest - (lastDigit << 1);
            }
            if (remaining == 0 || remaining%7 == 0)
                return true;

            return false;
        }

        // ******** dificult to remember **********
        private static bool IsDivisibleBy8(long n)
        {
            long rem = n%1000;
            return (rem%8) == 0;
        }

        private static bool IsDivisibleBy9(long n)
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
