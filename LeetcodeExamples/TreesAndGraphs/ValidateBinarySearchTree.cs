using LeetcodeExamples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.TreesAndGraphs
{
    public class ValidateBinarySearchTree
    {
        public static bool IsValidBST(TreeNode root)
        {
            return CheckBST(root, null , null);
        }


        private static bool CheckBST(TreeNode root, int? low, int? high)
        {

            if (root == null) return true;

            if ((low.HasValue && root.val >= low)) return false;
            if ((high.HasValue && root.val <= high)) return false;


            return CheckBST(root.left, root.val, high) && CheckBST(root.right, low, root.val);

        }

        public static void Run()
        {
            TreeNode root = new TreeNode
            {
                val = 5,
                left = new TreeNode
                {
                    val = 4,
                    left = null,
                    right = null
                },
                right =new TreeNode
                {
                    val =6,
                    left =new TreeNode
                    {
                        val =3,
                        left =null,
                        right = null
                    },
                    right= new TreeNode
                    {
                        val = 7,
                        left = null,
                        right = null
                    }
                    
                }
            };

            var output = IsValidBST(root);
        }
    }
}
