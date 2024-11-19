using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Recursion
{
    public class Subsets
    {
        public static IList<IList<int>> Subset(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();
            results.Add(new List<int>());
            List<int> list = null;
            List<List<int>> concateList = new List<List<int>>();

            foreach (int i in nums)
            {
                var counter = 0;
                list = new List<int>();
                concateList = new List<List<int>>();
                while (counter< results.Count)
                {
                    if (results[counter].Count ==0)
                    {
                        list.Add(i);
                        counter++;
                        continue;
                    }
                    else
                    {
                        var list1 = results[counter].ToList();

                        list1.Add(i);
                        concateList.Add(list1);

                        counter++;
                    }
                }
                results.Add(list);

                if (concateList.Count > 0)
                {
                   
                    foreach (var v in concateList)
                    {
                        results.Add(v);
                    }
                }
            }
            return results;
        }

        public static void Run()
        {
            int[] nums = [1,2,3];
            var output = Subset(nums);

        }
    }
}
