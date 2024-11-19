using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.SortingSearching
{
    public class IntersectionOfTwoArrays
    {


        public static int[] Intersect_version2(int[] nums1, int[] nums2)
        {

            Array.Sort(nums1);
            Array.Sort(nums2);

            int i = 0;
            int j = 0;
            int k = 0;
            

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else if (nums1[i] > nums2[j]) 
                {
                    j++; 
                }
                else
                {
                    if (nums1.Length > nums2.Length)
                    {
                        nums1[k++] = nums1[++i];
                        ++j;
                    }
                    else
                    {
                        nums1[k++] = nums2[++j];
                        ++i;
                    }
                        
                }
            }

            var output = nums1.Chunk(k).ToArray()[0];

            return output;
        }

            public static int[] Intersect(int[] nums1, int[] nums2)
        {

            ILookup<int, int> lookup1 = nums1.ToLookup(i => i);
            ILookup<int, int> lookup2 = nums2.ToLookup(i => i);

            int[] output =
            (
            from group1 in lookup1
            let group2 = lookup2[group1.Key]
            where group2.Any()
            let smallerGroup = group1.Count() < group2.Count() ? group1 : group2
            from i in smallerGroup
            select i
            ).ToArray();

  

            return output;

        }

        public static void Run()
        {
            int [] nums2 = [1, 2, 2,2, 1];
            int[] nums1 = [2, 2];

            var output = Intersect_version2(nums1 , nums2 );  

        }

    }
}
