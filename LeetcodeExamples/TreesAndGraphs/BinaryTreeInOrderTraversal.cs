using LeetcodeExamples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.TreesAndGraphs
{
    public class BinaryTreeInOrderTraversal
    {
        static IList<int> result = new List<int>();

        public static IList<int> InorderTraversal(TreeNode root)
        {
            return TraverseList(root);
        }

        private static IList<int> TraverseList(TreeNode root)
        {
           if(root == null) return result;

           TraverseList(root.left);
            result.Add(root.val);
            TraverseList(root.right);
            return result;
        }


        public static void Run()
        {
            TreeNode root = new TreeNode
            {
                val = 1,
                left = null,
                right = new TreeNode
                {
                    val = 2,
                    left = new TreeNode
                    {
                        val = 3,
                    },
                    right = null
                }
            };

            var output = InorderTraversal(root);

        }
    }
}
