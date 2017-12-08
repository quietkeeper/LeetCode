using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ListNode
    {
        public ListNode(int value)
        {
            val = value;
        }
        public ListNode(int value,ListNode node)
        {
            val = value;
            next = node;
        }
        public ListNode(string value)
        {
            strValue = value;
        }
        public ListNode(string value, ListNode node)
        {
            strValue = value;
            next = node;
        }
        public ListNode next;
        public int val;
        public string strValue;
    }
    public class TreeNode
    {
        public TreeNode(int value)
        {
            val = value;
        }

        public TreeNode(string value)
        {
            strValue = value;
        }
        public TreeNode left;
        public TreeNode right;
        public int val;
        public string strValue;
    }

   // class 
}
