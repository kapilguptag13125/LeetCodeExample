using LeetcodeExamples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Tests
{
    public class SortLists
    {
        public static ListNode SortList(ListNode head)
        {

            if (head == null || head.next==null)
                return head;

            ListNode node = new ListNode(0, null);
            ListNode current = node;

            

            return head;
        }

        private static ListNode SwapNode(ListNode node, ListNode nextNode)
        {
            if (node != null && nextNode != null) {

                if (node.val > nextNode.val)
                {

                    ListNode temp = nextNode;
                    nextNode.next = node;
                    node.next = temp.next;
                    return (SwapNode(node, temp));  
                }

                return node;
            }
            return node;
        }



        public static void Run()
        {
            ListNode node = new ListNode
            {
                val = 4,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 1,
                        next = new ListNode
                        {
                            val = 3,
                            next = null
                        }
                    }

                }
            };

            var output = SortList(node);
        }
    }
}
