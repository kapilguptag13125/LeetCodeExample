using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Medium
{
    public class NextPermutationExample
    {

        public void NextPermutation(int[] nums)
        {
            int index = -1;
            int n = nums.Length;
            for (int i = n - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Array.Reverse(nums, 0, n);
                return;
            }
            for (int i = n - 1; i >= 0; i--)
            {
                if (nums[index] < nums[i])
                {
                    int swap = 0;
                    swap = nums[i];
                    nums[i] = nums[index];
                    nums[index] = swap;
                    break;
                }
            }
            Array.Reverse(nums, index + 1, n - 1 - index);
        }

        public static void Run()
        {
            int[][] intervals =
[[5, 10], [6, 8], [1, 5], [2, 3], [1, 10]];


            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            NextPermutationExample example = new NextPermutationExample();
            example.NextPermutation([1,3,2]);
        }

    }
}
