using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Tests
{
    public class MaximumSizeSumArrayToK
    {

        public static int MaxSubArrayLen(int[] nums, int k)
        {
            int prefixSum = 0;
            int longestSubArray = int.MinValue;

            int left = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];

                while( prefixSum== k)
                {
                   longestSubArray = Math.Max(longestSubArray, i-left+1);
                }
            }

            return longestSubArray;
        }



        public  static int MaxSubArrayLen_v1(int[] nums, int k)
        {
            int prefixSum = 0;
            int longestSubArray = 0;

            Dictionary<int, int> indicies =new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];

                if (prefixSum == k)
                {
                    longestSubArray = i + 1;
                }

                if (indicies.ContainsKey(prefixSum - k))
                {
                    longestSubArray = Math.Max(longestSubArray, i - indicies[prefixSum - k]);
                }

                if (!indicies.ContainsKey(prefixSum))
                {
                    indicies[prefixSum] = i;    
                }
            }

            return longestSubArray;
        }
        public static void Run()
        {
            int[] nums = [1, -1, 5, -2, 3];
            //nums = [-2, -1, 2, 1];
          //  nums = [-1];
            //nums = [-1, 1];
            int k = 3;
            //k = -1;
            //k = 1;


            var output = MaxSubArrayLen(nums, k);
        }

    }
}
