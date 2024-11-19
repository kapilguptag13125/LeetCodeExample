using LeetcodeExamples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Tests
{
    public class SortLinkedLists
    {
        public static ListNode MergeTwoLists_v1(ListNode list1, ListNode list2)
        {

            if (list1 == null && list2 == null)
            {
                return null;
            }

            if (list1 == null)
                return list2;

            if (list2 == null)
            {
                return list1;
            }

            ListNode lstNode = new ListNode(0, null);
            ListNode current = lstNode;

            while (list1 != null && list2 != null)
            {

                if (list1.val < list2.val)
                {

                    current.next = new ListNode(list1.val, null);
                    current = current.next;

                    list1 = list1.next;
                }
                else if (list1.val > list2.val)
                {
                    current.next = new ListNode(list2.val, null);
                    current = current.next;

                    list2 = list2.next; 
                }
                else
                {
                    current.next = new ListNode(list1.val, null);
                    current = current.next;

                    current.next = new ListNode(list2.val, null);
                    current = current.next;

                    list1 = list1.next;
                    list2 = list2.next;
                }

            }

            while(list1!=null)
            {
                current.next = new ListNode(list1.val, null);
                current=current.next;
                list1 = list1.next;

            }

            while (list2 != null)
            {
                current.next = new ListNode(list2.val, null);
                current = current.next;
                list2 = list2.next;

            }
            return lstNode.next;
        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {

            if (list1 == null && list2 == null)
            {
                return null;
            }

            if (list1 == null)
                return list2;

            if (list2 == null)
            {
                return list1;
            }

            ListNode lstNode = new ListNode(0, null);
            ListNode current = lstNode;

            while (list1 != null && list2 != null)
            {

                if (list1.val < list2.val)
                {

                    current.next = new ListNode(list1.val, null);
                    current = current.next;

                    list1 = list1.next;
                }
                else if (list1.val > list2.val)
                {
                    current.next = new ListNode(list2.val, null);
                    current = current.next;

                    list2 = list2.next;
                }
                else
                {
                    current.next = new ListNode(list1.val, null);
                    current = current.next;

                    current.next = new ListNode(list2.val, null);
                    current = current.next;

                    list1 = list1.next;
                    list2 = list2.next;
                }

            }

            while (list1 != null)
            {
                current.next = new ListNode(list1.val, null);
                current = current.next;
                list1 = list1.next;

            }

            while (list2 != null)
            {
                current.next = new ListNode(list2.val, null);
                current = current.next;
                list2 = list2.next;

            }
            return lstNode.next;
        }

        public static void Run()
        {

            ListNode node = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 4,
                        next = null
                    }

                }
            };

            ListNode node1 = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 3,
                    next = new ListNode
                    {
                        val = 4,
                        next = null
                    }

                }
            };

            node = new ListNode
            {
                val = 2,
                next = null
            };

            node1 = new ListNode
            {
                val = 1,
                next = null
            };

            var output = MergeTwoLists(node, node1);

        }
    }
}
