using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Tests
{
    internal class SubArrayProductLessThanK
    {

        public static int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1) return 0; // If k is less than or equal to 1, no subarray can satisfy the condition

            int left = 0, right = 0, product = 1, count = 0; // Initialize pointers, product, and count
            int n = nums.Length; // Length of the array

            while (right < n)
            { // Iterate through the array
                product *= nums[right]; // Extend the window by including nums[right] in the product
                while (product >= k) // Shrink the window if product is greater than or equal to k
                    product /= nums[left++]; // Remove leftmost value from the product and shrink the window
                count += 1 + (right - left); // Count all subarrays that end at right index and satisfy the condition
                right++; // Move the right pointer to the right
            }
            return count; // Return the total count of subarrays
        }

        public static void Run()
        {
            int[] nums = [10, 5, 2, 6];
            int k = 100;

            var output = NumSubarrayProductLessThanK(nums, k);
        }
    }
}
