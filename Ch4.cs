using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NCProjects
{
    public class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }

        public ListNode(int val)
        {
            this.val = val;
            next = null;
            
        }
    }
    public class Ch4
    {
        public ListNode RemoveDuplicate(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode curt = head;
            while (curt.next != null)
            {
                if (curt.val == curt.next.val)
                {
                    curt.next = curt.next.next;
                }
                else
                    curt = curt.next;
            }
            return head;
        }

        public ListNode RemoveDuplicateII(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode preHead = new ListNode(0);
            preHead.next = head;

            ListNode curt = head;
            ListNode preCurt = preHead;

            while (curt != null && curt.next != null)
            {
                if (curt.val == curt.next.val)
                {
                    while (curt.val == curt.next.val)
                    {
                        curt = curt.next;
                    }
                    preCurt.next = curt.next;
                    curt = curt.next;
                }
                else
                {
                    preCurt = preCurt.next;
                    curt = curt.next;
                }
            }
            return preHead.next;
        }
        public ListNode Reverse(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode pre = null;
            while (head.next != null)
            {
                ListNode temp = head.next;
                head.next = pre;
                pre = head;
                head = temp;
            }
            head.next = pre;
            return head;
        }

        public ListNode ReverseII(ListNode head, int m, int n)// I had a bug here 
        {
            if (head == null || head.next == null || m > n)
            {
                return head;
            }
            ListNode preM = new ListNode(0) { next=head}, M = head;
            for (int i = 1; i < m; i++)
            {
                if (M == null)
                    return head;
                preM = preM.next;
                M = M.next;
            }

            ListNode N = M, postN = M.next;
            for (int i = m; i < n; i++)
            {
                if (postN == null)
                    return head;
                ListNode temp = postN.next;
                postN.next = N;
                N = postN;
                postN = temp;
            }

            preM.next = N;
            M.next = postN;

            return head;
        }

        public ListNode Partition(ListNode head, int value)
        {
            if (head == null || head.next == null)
                return head;
            ListNode left = new ListNode(0);
            ListNode right = new ListNode(0);
            ListNode lCurrent = null, rCurrent = null;
            ListNode curt = head;

            while (curt != null)
            {
                if (curt.val < value)
                {
                    if (lCurrent == null)
                    {
                        
                        lCurrent = curt;
                        left.next=lCurrent;
                        curt = curt.next;
                    }
                    else
                    {
                        lCurrent.next = curt;
                        lCurrent = lCurrent.next;
                        curt = curt.next;
                    }
                }
                else
                {
                    if (rCurrent == null)
                    {
                        rCurrent = curt;
                        right.next=rCurrent;
                        curt = curt.next;
                    }
                    else
                    {
                        rCurrent.next = curt;
                        rCurrent = rCurrent.next;
                        curt = curt.next;
                    }
                }
            }
            rCurrent.next = null;// this is important
            if (left.next == null)
                return right.next;
            lCurrent.next = right.next;
            
            return left.next;

        }
    }
}
