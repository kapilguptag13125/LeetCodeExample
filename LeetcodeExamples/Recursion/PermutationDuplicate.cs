using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Recursion
{
    internal class PermutationDuplicate
    {

        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();
            Dictionary<int, int> counter = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!counter.ContainsKey(num))
                    counter.Add(num, 0);
                counter[num]++;
            }

            List<int> comb = new List<int>();
            Backtrack(comb, nums.Length, counter, results);
            return results;
        }

        private static void Backtrack(List<int> comb, int N, Dictionary<int, int> counter,
                               List<IList<int>> results)
        {
            if (comb.Count == N)
            {
                results.Add(new List<int>(comb));
                return;
            }

            foreach (var entry in counter.ToList())
            {
                int num = entry.Key;
                int count = entry.Value;
                if (count == 0)
                    continue;
                comb.Add(num);
                counter[num]--;
                Backtrack(comb, N, counter, results);
                comb.RemoveAt(comb.Count - 1);
                counter[num]++;
            }
        }

        public static void Run()
        {
           var output = PermuteUnique([1, 1, 2]);
        }
    }
}
