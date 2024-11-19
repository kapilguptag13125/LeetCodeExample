using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Recursion
{
    public class StrobogrammaticNumber
    {
        public static char[][] reversiblePairs = [
                                                ['0', '0'], ['1', '1'],
                                                ['6', '9'], ['8', '8'], ['9', '6']];

        public static IList<string> FindStrobogrammatic(int n)
        {
            var output  = generateStroboNumbers(n, n);

            return output;
        }

        public static List<String> generateStroboNumbers(int n, int finalLength)
        {
            if (n == 0)
            {
                // 0-digit strobogrammatic number is an empty string.
                return new List<string> { "" };
            }

            if (n == 1)
            {
                // 1-digit strobogrammatic numbers.
                return new List<string> { "0", "1", "8" };
            }

            List<String> prevStroboNums = generateStroboNumbers(n - 2, finalLength);
            List<String> currStroboNums = new List<string>();

            foreach (String prevStroboNum in prevStroboNums)
            {
                foreach (char[] pair in reversiblePairs)
                {
                    // We can only append 0's if it is not first digit.
                    if (pair[0] != '0' || n != finalLength)
                    {
                        currStroboNums.Add(pair[0] + prevStroboNum + pair[1]);
                    }
                }
            }

            return currStroboNums;
        }


        public static void Run()
        {
            var output = FindStrobogrammatic(3);
        }
    }
}
