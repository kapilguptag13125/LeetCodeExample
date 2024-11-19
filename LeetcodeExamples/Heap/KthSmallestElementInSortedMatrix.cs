//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LeetcodeExamples.Heap
//{
//    public class KthSmallestElementInSortedMatrix
//    {
//        private class MyHeapNode
//        {
//            int row;
//            int column;
//            int value;

//            public MyHeapNode(int v, int c, int r)
//            {
//                row = r; column = v; value = c;
//            }

//            public int GetValue() { return value; }
//            public int GetRow() { return row; }
//            public int GetColumn() { return column; }
//        }

//        public static int KthSmallest(int[][] matrix, int k)
//        {

//            var comparable = Comparer<int, MyHeapNode>.Create(int, MyHeapNode x, MyHeapNode y)=> { return x.GetValue() + y.GetValue()};

//            PriorityQueue<int, MyHeapNode> priorityQueue = new PriorityQueue<int, MyHeapNode>();

//            int N = matrix.Length;

//            for (int r = 0; r < Math.Min(N, k); r++)
//            {
//                // We add triplets of information for each cell
//                priorityQueue.Enqueue(matrix[r][0],  new MyHeapNode(matrix[r][0], r, 0));
//            }

//            return 0;
//        }

//        public static void Run()
//        {

//            int [][]matrix = [[1, 5, 9], [10, 11, 13], [12, 13, 15]];
//            int k =8;

//            var output = KthSmallest(matrix, k);    

//        }
//    }
//}
