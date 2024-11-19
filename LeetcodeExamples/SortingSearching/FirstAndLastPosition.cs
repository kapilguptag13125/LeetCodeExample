using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.SortingSearching
{
    public class FirstAndLastPosition
    {
        public static int[] SearchRange(int[] nums, int target)
        {
            if (!nums.Any())
            {
                return [-1,-1];
            }

            if (nums.Length==1)
            {
                if (nums[0] == target)
                {
                    return [0, 0];
                }
            }


            var firstIndex = FindBound(nums, target);
            if (firstIndex ==-1)
            {
                return [-1, -1];
            }

            int index = firstIndex;
            int secondIndex = -1;
            while (index < nums.Length)
            {
                if ((index +1 < nums.Length) &&  nums[index+1] ==target)
                {
                    secondIndex = index + 1;
                    index++;
                }
                else
                {
                    break;
                }
            }

            return [firstIndex, secondIndex];

        }

        private static int FindBound(int[] nums, int target)
        {
            int begin = 0;
            int end = nums.Length - 1;

            while (begin < end)
            {
                int mid =  (begin + end) / 2;

                if (nums[mid] == target)
                {
                    return mid - 1;
                }
                else if (nums[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    begin = mid + 1;
                }
            }
            return -1;
        }


        public static void Run()
        {
            int[] nums = [1,1,1];
            int target = 1;

            var output = SearchRange(nums, target);
        }
    }
}
