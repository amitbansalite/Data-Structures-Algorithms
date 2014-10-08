using System;

//Input:  azxxzy
//Output: ay

//First "azxxzy" is reduced to "azzy". The string "azzy" contains duplicates, 
    //so it is further reduced to "ay".

namespace Algorithms.Problems.Recursion
{
    public class RemoveDuplicatesRecursively
    {
        private void Recur(String str, int index)
        {
            if (index >= str.Length)
            {
                return;
            }

            int pos = index;
            int n = str.Length;

            while (pos < n && str[pos] == str[index])
            {
                pos++;
            }

            if (pos - index > 1)
            {
                str = str.Remove(index, pos-index);
                if ( str.Length != 0)
                    Console.WriteLine(str);
                else
                    Console.WriteLine(" String empty");
                Recur(str, Math.Max(0, index-1));
            }
            else
            {
                Recur(str, index+1);
            }
        }

        public void Test()
        {
            var str = "azxxxzay";
            var str2 = "geeksforgeeks";
            var str3 = "caaabbbaacdddd";
            var str4 = "abcdef";

            Recur(str3, 0);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
