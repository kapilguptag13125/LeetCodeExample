using LeetcodeExamples.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.TreesAndGraphs
{
    public class BinaryTreePath
    {
       
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            var paths = new List<string>();
            AddBinaryPath(root,"", paths);
            return paths;
        }

        private static void AddBinaryPath(TreeNode root, string path, List<string> paths)
        {
            if (root != null)
            {
                path += Convert.ToString(root.val);
                if ((root.left == null) && (root.right == null))  // if reach a leaf
                {
                    Console.WriteLine(path);

                    paths.Add(path);  // update paths
                }
                else
                {
                    path += "->";  // extend the current path
                    Console.WriteLine(path);
                    AddBinaryPath(root.left, path, paths);
                    AddBinaryPath(root.right, path, paths);
                }
            }

            //if (treeNode != null)
            //{
            //    current.Add(treeNode.val.ToString());

            //    if ((treeNode.left == null) && (treeNode.right == null))
            //    {
            //        results.Add(string.Join(",", current));

            //    }
            //    else
            //    {

            //        AddBinaryPath(treeNode.left, current);
            //        AddBinaryPath(treeNode.right, current);
            //    }
            //}
        }

        public static void Run()
        {

            TreeNode root = new TreeNode
            {
                val = 1,
                left = new TreeNode
                {
                    val = 2,
                    left = null,
                    right = new TreeNode
                    {
                        val = 5,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode
                {
                    val = 3,
                    left = null,
                    right =null

                }
            };

            BinaryTreePaths(root);
        }
    }
}
