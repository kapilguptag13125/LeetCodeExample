using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Recursion
{
    public class RemoveInvalidParentheses
    {
        public static IList<string> RemoveInvalidParenthes(string s)
        {
            List<string> result = new List<string>();

            if (s.Length == 1)
            {
                return new List<string>();
            }

            if (s.Length <=2 && s.StartsWith(")"))
            {
                return new List<string>();
            }

           Stack<char> stack = new Stack<char>();

            List<int> charNeedsToBeRemoved = new List<int>();
            for(int i=0; i<s.Length;i++)
            {
                char c = s[i];
                if (s[i] == '(')
                {
                    stack.Push(s[i]);
                }
                else if (s[i] == ')')
                {
                    if (stack.Any())
                    {
                        stack.TryPeek(out char lastChar);

                        if (lastChar == '(')
                        {
                            stack.Pop();
                            continue;
                        }
                        else
                        {
                            charNeedsToBeRemoved.Add(i);
                        }

                    }
                    else
                    {
                        charNeedsToBeRemoved.Add(i);
                    }
                }

            }



            if (stack.Any() || charNeedsToBeRemoved.Any())
            {
                foreach (var j in charNeedsToBeRemoved)
                {
                   result.Add( s.Remove(j,1));
                   
                }
            }

            return result;
        }

        public static void Run()
        {
            string s = ")(";
            var output = RemoveInvalidParenthes(s);
        }
    }
}
