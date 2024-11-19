using LeetcodeExamples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Hard
{
    public class VerticalOrderTraversalBinaryTree
    {
        public static IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();    
            queue.Enqueue((root, 0));
            Dictionary<int, List<int>> keyValuePairs = new Dictionary<int, List<int>>();    
            while (queue.Count > 0)
            {
                (var node, var level) = queue.Dequeue();
                if (node != null)
                {
                    if (!keyValuePairs.TryGetValue(level, out var value))
                    {
                        keyValuePairs[level] = [node.val];
                    }
                    else
                    {
                        keyValuePairs[level].Add(node.val);
                    }
                    if (node.left!=null)
                        queue.Enqueue((node.left, level-1));

                    if (node.right!=null)
                        queue.Enqueue((node.right, level+1));
                }
            }

            foreach(var key in keyValuePairs.Keys.ToList().OrderBy(t=>t))
            {
                result.Add(keyValuePairs[key].OrderBy(t=>t).ToList());

            }

            return result;
        }
       

        public static void Run()
        {
            TreeNode tree = new TreeNode
            {
                val = 3,
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

            var output = VerticalTraversal(tree);

        }
    }
}
