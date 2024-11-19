using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Heap
{
    public class LastStoneWeight
    {

        public static int LastStoneWeig(int[] stones)
        {

            var maxHeapComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));

            PriorityQueue<int, int> priorityQueue = new(maxHeapComparer);

            Array.Sort(stones);

            for(int i = 0;i<stones.Length; i++)
            {
                priorityQueue.Enqueue(stones[i], stones[i]);    
            }

            while(priorityQueue.Count > 1)
            {
                int X = priorityQueue.Dequeue();
                int Y = priorityQueue.Dequeue();

                if (X!=Y)
                {
                    priorityQueue.Enqueue(X - Y, X - Y);
                }

            }

            return priorityQueue.Peek();
        }

        public static void Run()
        {
            int[] stones = [2, 7, 4, 1, 8, 1];
               var output = LastStoneWeig(stones); 
        }
    }
}
