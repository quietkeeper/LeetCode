using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCProjects
{
    class Helper
    {
        public static ListNode Reverse(ListNode node)
        {
            ListNode prev = null;
            while (node.next != null)
            {
                ListNode temp = node.next;
                node.next = prev;
                prev = node;
                node = temp;
            }
            node.next = prev;
            return node;
        }

        private string ReverseString(string str)
        {
            if (str == null )
                return str;
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }
    }
}
