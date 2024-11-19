using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Heap
{
    public class KthLargestElementInArray
    {

        public static int FindKthLargest(int[] nums, int k)
        {

            PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>();
            priorityQueue.EnsureCapacity(k);

            for(int i=0; i< k; i++)
            {
                priorityQueue.Enqueue(nums[i], nums[i]);
            }

            for(int i=k; i< nums.Length; i++)
            {
                if (nums[i]>=priorityQueue.Peek())
                {
                    priorityQueue.Dequeue();
                    priorityQueue.Enqueue(nums[i], nums[i]);
                }
            }

            return priorityQueue.Peek();

        }

        public static void Run()
        {
            int[] nums = [3, 2, 1, 5, 6, 4];
            nums = [3, 2, 3, 1, 2, 4, 5, 5, 6];
            int k = 4;
           var output = FindKthLargest(nums, k);
        }
    }
}
