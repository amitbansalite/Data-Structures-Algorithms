using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.Strings
{
    public class PrintLast10Lines
    {
        private void PrintLines(int numLines, string text)
        {
            int i = text.Length -1;
            int count = 0;

            while (count < numLines && i > 0)
            {
                if (text[i] == '\n')
                {
                    count++;
                }
                i--;
            }
            i++;

            for (int j = i+1; j < text.Length - 1; j++)
            {
                Console.Write(text[j]);
            }
            string result = text.Substring(i);
            //Console.WriteLine(result);
        }

        public void Test()
        {
            var text = @"hello1
                         hello2
                            hi3
                         hello4
                         hello5
                            hi6
                        hello7
                         hello8
hi9
                        hello10
hello11
         hi12
                        hello13
                         hello14
                            hi15
                            hello16
                         hello17
                            hi18";
            PrintLines(10, text);

            Console.ReadLine();
        }
    }
}
