using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Recursion
{
    public class PermutationNumber
    {
        public static IList<IList<int>> GetPermutationCombinations(int[] numbers)
        {
            IList<IList<int>> combinations = new List<IList<int>>();    
            GetCombination(numbers, combinations, new List<int>());
            return combinations;
        }

        private static void GetCombination(int[] numbers, IList<IList<int>> result, List<int> curr)
        {
            if (curr.Count == numbers.Length)
            {
                result.Add(new List<int>(curr));
                return;
            }

            foreach (int i in numbers)
            {
                if (!curr.Contains(i))
                {
                    curr.Add(i);
                    GetCombination(numbers, result, curr);

                    curr.RemoveAt(curr.Count - 1);    
                }
            }
        }

        public static void Run()
        {
            var output = GetPermutationCombinations([1,1,2]);
        }
    }
}
