using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Tests
{
    public class ContigiousArray
    {
        public static int FindMaxLength(int[] nums)
        {

            int max = 0;
            int count = 0;

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            keyValuePairs[0] = -1;

            for (int i=0; i<nums.Length; i++)
            {
                if (nums[i] ==1)
                    count++;
                else
                    count--;

                if (keyValuePairs.ContainsKey(count))
                {
                    max = Math.Max(max, i- keyValuePairs[count]);    
                }
                else
                    keyValuePairs[count] = i;
            }
            return max;
        }
        public static void Run()
        {
            int[] nums = [0, 1];

            var output = FindMaxLength(nums);

        }
    }
}
