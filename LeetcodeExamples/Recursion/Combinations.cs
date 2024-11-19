using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Recursion
{
    public class Combinations
    {
        public static int GetCombinations(int numberOfStories)
        {
            List<string> combinations = new List<string>();
            GetCombination(numberOfStories, string.Empty, combinations);
            return combinations.Count;
        }

        private static void GetCombination(int numberOfCombinations, string result, List<string> answers)
        {
            if (numberOfCombinations ==0)
            {
               answers.Add(result.Substring(0,result.Length-1));
                return;
            }

            if (numberOfCombinations >= 1)
            {
                GetCombination(numberOfCombinations-1, result + "small-", answers);
            }

            if (numberOfCombinations >= 2)
            {
                GetCombination(numberOfCombinations - 2, result + "large-", answers);
            }
        }

        public static void Run()
        {
            var output = GetCombinations(3);
        }
    }
}
