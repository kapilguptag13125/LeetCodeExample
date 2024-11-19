using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Hard
{
    internal class RemoveInvalidPrenthcs
    {
        public static List<String> removeInvalidParentheses(String s)
        {
            List<String> res = new List<string>();
            char[] check = new char[] { '(', ')' };
            dfs(s, res, check, 0, 0);
            return res;
        }

        public static void dfs(String s, List<String> res, char[] check, int last_i, int last_j)
        {
            int count = 0;
            int i = last_i;
            while (i < s.Length && count >= 0)
            {

                if (s[i] == check[0]) count++;
                if (s[i] == check[1]) count--;
                i++;
            }

            if (count >= 0)
            {
                // no extra ')' is detected. We now have to detect extra '(' by reversing the string.
                String reversed = new string( s.Reverse().ToArray());
                if (check[0] == '(') dfs(reversed, res, new char[] { ')', '(' }, 0, 0);
                else res.Add(reversed);

            }

            else
            {  // extra ')' is detected and we have to do something
                i -= 1; // 'i-1' is the index of abnormal ')' which makes count<0
                for (int j = last_j; j <= i; j++)
                {
                    if (s[j] == check[1] && (j == last_j || s[j - 1] != check[1]))
                    {
                        dfs(s.Substring(0, j) + s.Substring(j + 1, s.Length-j-1), res, check, i, j);
                    }
                }
            }
        }

        public static void Run()
        {
            string s = "()())()";
            var output = removeInvalidParentheses(s);
        }
    }
}
