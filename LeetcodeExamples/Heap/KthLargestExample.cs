
namespace LeetcodeExamples.Heap
{
    public class KthLargestExample
    {
        int[] data;
        int K;
        PriorityQueue<int, int> priorityQueue;
        public KthLargestExample(int k, int[] nums)
        {
            data = nums;
            K = k;

            priorityQueue = new PriorityQueue<int, int>();

            for (int i = 0; i < K; i++)
            {
                priorityQueue.Enqueue(nums[i], nums[i]);   
            }

            for (int i = k; i < nums.Length; i++)
            {
                _ = Add(nums[i]);
            }
        }

     
        public int Add(int val)
        {
            if (val > priorityQueue.Peek())
            {
                priorityQueue.Dequeue();
                priorityQueue.Enqueue(val,val);
            }

            return priorityQueue.Peek();
        }

        public static void Run()
        {
            int k = 3;
            int[] nums = [4, 5, 8, 2];

            KthLargestExample obj = new KthLargestExample(k, nums);

            var output = obj.priorityQueue.Peek();

            Console.WriteLine( obj.Add(3));
            Console.WriteLine(obj.Add(5));
            Console.WriteLine(obj.Add(10));
            Console.WriteLine(obj.Add(9));
            Console.WriteLine(obj.Add(4));
        }
    }
}
