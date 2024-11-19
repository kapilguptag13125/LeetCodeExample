using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Recursion
{
    public class PhoneNumberCombination
    {

        private static Dictionary<char, string> letters = new Dictionary<char, string> {
        { '2', "abc" }, { '3', "def" },  { '4', "ghi" }, { '5', "jkl" },
        { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" }
        };

        private static string phoneDigits;
        public static List<string> GetCombinations(string digits)
        {
            List<string> combinations = new List<string>();
            phoneDigits = digits;
            GetCombination(0, new StringBuilder(), combinations);
            return combinations;
        }

        private static void GetCombination(int index, StringBuilder path, List<string> result)
        {
            if (path.Length == phoneDigits.Length)
            {
                result.Add(path.ToString());
                return;
            }

            string possibleLetters = letters[phoneDigits[index]];
            foreach (char letter in possibleLetters.ToCharArray())
            {
                path.Append(letter);
                GetCombination(index +1, path, result);
                path.Remove(path.Length-1,1);
            }
        }


        public static void Run()
        {
            var output = GetCombinations("23");
        }
    }
}
