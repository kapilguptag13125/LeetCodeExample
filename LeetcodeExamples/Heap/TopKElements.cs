using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Heap
{
    public class TopKElements
    {

        public static int[] TopKFrequent(int[] nums, int k)
        {

            Dictionary<int, int> keyValuePairsMap = new Dictionary<int, int>();

            for(int i=0; i< nums.Length; i++)
            {
               if (keyValuePairsMap.TryGetValue(nums[i], out int value))
                {
                    keyValuePairsMap[nums[i]] = ++value; 
                }
               else
                {
                    keyValuePairsMap.Add(nums[i], 1);
                }
            }

            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            foreach (var key in keyValuePairsMap.Keys)
            {
                priorityQueue.Enqueue(key, keyValuePairsMap[key]);  
                if (priorityQueue.Count>k)
                {
                    priorityQueue.Dequeue();
                }
            }


            int[] data = new int[k];
            while(priorityQueue.Count > 0)
            {
                data[--k] = priorityQueue.Dequeue();
            }

            return data;
        }

        public static void Run()
        {
            int[] nums = [1, 1, 1, 2, 2, 3];
            nums = [1];
            int k = 2;
            k = 1;
           var output = TopKFrequent(nums, k);
        }
    }
}
