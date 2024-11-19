using LeetcodeExamples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Medium
{
    public class BinaryTreeVerticalOrderTraersal
    {
        public static IList<IList<int>> VerticalOrder(TreeNode root)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();

            Queue<(TreeNode, int, int)> queue = new Queue<(TreeNode, int, int)>();

            queue.Enqueue((root, 0, 1));

            while (queue.Any())
            {

                int i = 0;
                int count = queue.Count;

                while (i < count)
                {
                    (TreeNode node, int index, int depth) = queue.Dequeue();

                    if (!result.TryGetValue(index, out var datas))
                    {
                        result.Add(index, new List<int>());
                    }

                    result[index].Add(node.val);

                    if (node.left != null)
                    {
                        queue.Enqueue((node.left, index - 1, depth + 1));

                    }

                    if (node.right != null)
                    {
                        queue.Enqueue((node.right, index + 1, depth + 1));
                    }

                    i++;
                }
            }

            IList<IList<int>> res = new List<IList<int>>();
            foreach(var v in result.Keys.OrderBy(t=> t))
            {
                res.Add(result[v]);
            }


            return res;
        }

        public static void Run()
        {
            var root = new TreeNode
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

            var output = VerticalOrder(root);


        }
    }

}