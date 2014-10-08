//   System.Numerics.BigInteger : Represents an arbitrarily large signed integer.

namespace Algorithms.Problems.Recursion
{
    // 1. Even by using ulong data type, one cannot calculate 60! 

    // 2. By using long data type, one cannot calculate 25!

    public class Factorial
    {
        //public static void Main()
        //{
        //    var factorial = 4;

        //    //1. 
        //    long long_number = 1;
        //    for (var i = 1; i <= factorial; i++)
        //    {
        //        long_number *= i;
        //    }
        //    Console.WriteLine(long_number);

        //    // 2. 
        //    var bigInteger_number = new BigInteger(1);
        //    for (var i = 1; i <= factorial; i++)
        //    {
        //        bigInteger_number *= i;
        //    }
        //    Console.WriteLine(bigInteger_number);
            
        //    // 3. using LINQ
        //    var result = new BigInteger(1);
        //    Enumerable.Range(1, factorial).ToList().ForEach(element => result = result*element);
        //    Console.WriteLine(result);


        //    // 4. using LINQ
        //    var thisResult = Enumerable.Range(1, factorial).Aggregate( (counter, value) => counter*value);
        //    Console.WriteLine(thisResult);

        //    Console.Read();
        //}
    }
}
