using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetcodeExamples.SortingSearching
{
    public class PourWaterToMakeWaterLevelEqual_2137
    {
        public static double EqualizeWater(int[] buckets, int loss)
        {
            double low = Double.MaxValue;
            double high = Double.MinValue;

            foreach (double n in buckets)
            {
                if (low > n) low = n;
                if (high < n) high = n;
            }

            double factor = (double)100 / (double)(100 - loss);
            double ans = 0;

            while (low <= high)
            {
                double mid = (low + high) / 2;

                if (check(mid, buckets, factor))
                {
                    ans = Math.Max(ans, mid);
                    low = mid + 0.000001;
                }
                else
                {
                    high = mid - 0.000001;
                }
            }
            return ans;
        }

        public static bool check(double mid, int[] buckets, double factor)
        {
            double tmp = 0;

            foreach (double n in buckets)
            {
                if (mid >= n)
                {
                    tmp -= (mid - n) * factor;
                }
                else
                {
                    tmp += n - mid;
                }
            }

            return tmp >= 0;
        }

        public static void Run()
        {
            int[] nums = [2, 4, 6];
            int loss = 50;

            var output = EqualizeWater(nums, loss);
        }
    }
}
