using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.Sorting
{
    public class MSD_Radix_String_Jabez
    {
        private static void StringSort(string[] input)
        {
            var finalBucket = new Queue<string>[27];    //Holds the final result
            var bucket = new Queue<string>[27];

            //Instantiate Empty buckets
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new Queue<string>();
                finalBucket[i] = new Queue<string>();
            }
            
            //The sort algorithm is case-insensitive
            // int of a is 97

            var charPosition = 0;
            var index = 0;  //Starting from the MSD
            char character;
            
            var end = input.Length; //This will vary for each iteration 

            Queue<string> currBucket = null;

            while (true)
            {
                bool endCondition = true;
                for (int i = 0; i < end; i++)
                {
                    if (charPosition + 1 >= input[i].Length)
                    {
                        character = input[i].ToLower()[0]; //Lowercase string and take the MSD character
                        index = character - 97;
                        finalBucket[index].Enqueue(input[i]); 
                    }
                    else
                    {
                        endCondition = false;
                        character = input[i].ToLower()[charPosition]; 
                        index = character - 97;
                        bucket[index].Enqueue(input[i]);
                    }                    
                }

                //Breaking condition
                if(endCondition)
                {
                    break;
                }

                //Reusing Index and repopulating input array                 
                index = 0;
                for (int i = 0; i < bucket.Length; i++)
                {
                    currBucket = bucket[i];
                    while (currBucket.Count > 0)
                    {
                        input[index++] = currBucket.Dequeue();
                    }
                }

                // Moving to the next significant position
                charPosition += 1;

                //Adjusting looping ending for next iteration
                end = index;
            }

            //Populating the final array
            index = 0;
            for (int i = 0; i <  finalBucket.Length; i++)
            {
                currBucket = finalBucket[i];
                while (currBucket.Count > 0)
                {
                    input[index++] = currBucket.Dequeue();
                }
            }
        }

    }
}
