using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Heap
{
    public class KWeakestRowsInMatrix
    {
        public static int[] KWeakestRows(int[][] mat, int k)
        {
            PriorityQueue<int, (int, int)> pq = new PriorityQueue<int, (int, int)>(Comparer<(int, int)>.Create((x, y) =>
            {
                if (x.Item2 == y.Item2)
                {
                    return x.Item1 - y.Item1;
                }
                return x.Item2 - y.Item2;
            }));

            for (int i = 0; i < mat.Length; i++)
            {
                pq.Enqueue(i, (i, mat[i].Sum()));
            }

            int[] res = new int[k];

            for (int i = 0; i < k; i++)
            {
                res[i] = pq.Dequeue();
            }

            return res;
        }

        public static void Run()
        {

            int[][] nums =
                    [[1,1,0,0,0],
                 [1,1,1,1,0],
                 [1,0,0,0,0],
                 [1,1,0,0,0],
                 [1,1,1,1,1]];

            int k = 3;

            var output = KWeakestRows(nums, k);

        }
    }
}
