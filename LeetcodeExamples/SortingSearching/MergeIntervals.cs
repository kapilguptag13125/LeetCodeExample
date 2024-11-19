using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.SortingSearching
{
    public class MergeIntervals
    {
        public static int[][] Merge(int[][] intervals)
        {
            Comparer<int> comparer = Comparer<int>.Default;
            Array.Sort(intervals, (a, b) => { return a[0] - b[0]; });


            int counter = 0;
            foreach (var interval in intervals)
            {
                if (counter==0)
                {
                    counter++;
                }
                else
                {
                    if (intervals[counter - 1][1] >= interval[0] )
                    {
                        var end = (intervals[counter - 1][1] > interval[1]) ? intervals[counter - 1][1] : interval[1];

                        intervals[counter - 1][1] = end;
                    }
                    else
                    {
                        intervals[counter] = interval;
                        counter++;
                    }
                }
            }

            return intervals.Chunk(counter).ToArray()[0];


        }

        public static void Run()
        {
            //int[][] nums = [[2, 6], [1, 3],  [8, 10], [15, 18]];
            //int[][] nums = [[5,10], [5,11],  [8, 10], [15, 18]];
            int[][] nums = [[0, 30], [60, 240], [90, 120]];
            var output = Merge(nums);
        }
    }
}
