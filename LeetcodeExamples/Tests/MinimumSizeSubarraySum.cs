using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Tests
{
    public class MinimumSizeSubarraySum
    {

        public static int MinSubArrayLen(int target, int[] nums)
        {
            int minSubArray = int.MaxValue;
            int left = 0;

            var sum = 0;

            for(int i=0; i< nums.Length; i++)
            {
                sum += nums[i];

                while(sum>= target)
                {
                    minSubArray = Math.Min(minSubArray, i - left + 1);
                    sum -= nums[left];
                    left++;
                }
            }

            return minSubArray!=int.MaxValue?minSubArray:0;
        }

        public static void Run()
        {
            int[] nums = [2, 3, 1, 2, 4, 3];
            int target = 7;

            var output = MinSubArrayLen(target, nums);

        }
    }
}
