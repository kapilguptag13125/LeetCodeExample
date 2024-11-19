using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.SortingSearching
{
    public class FindPeekElement
    {
        public static int FindPeakElement(int[] nums)
        {

            int l = 0, r = nums.Length - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] > nums[mid + 1])
                    r = mid;
                else
                    l = mid + 1;
            }

            return l;

        }

        public static void Run()
        {
            int[] nums = [100, 2, 1, 3, 5, 6, 4];
            var output = FindPeakElement(nums);
        }
    }
}
