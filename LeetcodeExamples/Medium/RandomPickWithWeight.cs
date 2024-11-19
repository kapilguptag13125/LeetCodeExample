﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Medium
{
    public  class RandomPickWithWeight
    {
        private int[] prefixSums;
        private Random random;

        public RandomPickWithWeight(int[] w)
        {
            int n = w.Length;
            prefixSums = new int[n];
            prefixSums[0] = w[0];

            // Compute the prefix sums
            for (int i = 1; i < n; i++)
            {
                prefixSums[i] = prefixSums[i - 1] + w[i];
            }

            random = new Random();
        }

        public  int PickIndex()
        {
            int target = random.Next(1, prefixSums[^1] + 1);

            // Binary search for the target
            int left = 0, right = prefixSums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (prefixSums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        public static void Run()
        {
            RandomPickWithWeight obj = new RandomPickWithWeight([1,3]);

            var output = obj.PickIndex();
            Console.WriteLine(output);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(obj.PickIndex());
            }


        }
    }
}
