using LeetcodeExamples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.TreesAndGraphs
{
    public class FlatternBinaryTreeToLinkedList
    {

        public  static void Flatten(TreeNode root)
        {
            FlatternTree(root);
        }

        private static TreeNode FlatternTree(TreeNode root)
        {

            if (root == null) return null;

            if (root.left == null && root.right == null)
            {
                return root;
            }

            var leftTree = FlatternTree(root.left);

            var righTree = FlatternTree(root.right);

            if (leftTree != null)
            {
                leftTree.right = root.right;
                root.right = root.left;
                root.left = null;
            }

            return righTree == null ? leftTree : righTree;
        }


        public static void Run()
        {
            TreeNode root = new TreeNode
            {
                val = 1,
                left = new TreeNode
                {
                    val = 2,
                    left = new TreeNode
                    {
                        val =3,
                        left = null,
                        right =null
                    },
                    right = new TreeNode
                    {
                        val = 4,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode
                {
                    val = 5,
                    left = null,
                    right = new TreeNode
                    {
                        val = 6,
                        left = null,
                        right = null
                    }

                }
            };

            Flatten(root);
        }
    }
}
