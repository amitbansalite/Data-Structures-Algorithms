using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.Binary
{
    public class NumbersBinaryFormatPalindrome
    {
        private bool IsIthBitSet(uint n, int pos)
        {
            return (n & (1 << pos)) == 0;
        }

        private bool IsPalindrome(uint n)
        {
            int left = 0;
            int right = 4;  // find the position of the right most bit ???

            while (left <= right)
            {
                if ( IsIthBitSet(n, left) != IsIthBitSet(n, right) )
                    return false;
                left++;
                right--;
            }
            return false;
        }


        public void Test()
        {
            
        }
    }
}
