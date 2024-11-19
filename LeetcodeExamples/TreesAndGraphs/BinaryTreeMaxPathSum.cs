using LeetcodeExamples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.TreesAndGraphs
{
    public class BinaryTreeMaxPathSum
    {

        private static int maxSum = int.MinValue;
        public static int MaxPathSum(TreeNode root)
        {
            GainFromSubtree(root);
            return maxSum;
        }
        private static int GainFromSubtree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int gainFromLeft = Math.Max(GainFromSubtree(root.left), 0);
            int gainFromRight = Math.Max(GainFromSubtree(root.right), 0);

            maxSum = Math.Max(maxSum, gainFromRight + gainFromLeft + root.val);

            var outval = Math.Max(gainFromLeft + root.val, gainFromRight + root.val);
            
            Console.WriteLine($"MaxSum:{maxSum}, Righ:{gainFromRight}, Left: {gainFromLeft}, root: {root.val}");

            return outval;
        }

        public static void Run()
        {
            //TreeNode root = new TreeNode
            //{
            //    val = 1,
            //    left = new TreeNode
            //    {
            //        val=2,
            //        left =null,
            //        right = null

            //    },
            //    right = new TreeNode
            //    {
            //        val = 3,
            //        left = null,
            //        right = null
            //    }
            //};

            TreeNode root = new TreeNode
            {
                val = -10,
                left = new TreeNode
                {
                    val = 9,
                    left = null,
                    right = null

                },
                right = new TreeNode
                {
                    val = 20,
                    left = new TreeNode
                    {
                        val = 15,
                        left = null,
                        right = null
                    },
                    right = new TreeNode
                    {
                        val = 7,
                        left = null,
                        right = null
                    }
                }
            };
            var output = MaxPathSum(root);


        }
    }
}
