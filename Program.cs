using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode;

namespace NCProjects
{
    class Program
    {
        static void Main(string[] args)
        {

            string test = "fdasfsdafe";//"the sky is blue";
            //Console.WriteLine(ReverseWords(test));
            //Console.ReadKey();
            //Amazon oa = new Amazon();
            //int[][] points = new int[][]{new int[]{3,3},new int[]{5,-1},new int[]{-2,4}};
            //int[][] result=oa.KClosest(points, 2);

            //int[] arr = { 7, 10, 4, 3, 20, 15 };
            //int result = oa.QuickSelect(arr, 0, arr.Length - 1, 3);
            //Write(result);
            //foreach (int[] r in result)
            //{
            //    Write(r);
            //    Console.WriteLine();
            //}
            //Console.ReadKey();
            #region CH2
            int[] arrNoDuplicate = { 2, 4, 1, 7, 5, 9, 3 };
            int[] arrDuplicate = { 2, 4, 5, 31, 7, 62, 5, 7, 29, 3 };
            int[] arrSortedNoDuplicate = { 2, 4, 6, 12, 15, 18, 22, 31, 43 };
            int[] arrSortedDuplicate = { 2, 4, 6, 12, 12, 12, 15, 18, 18, 22, 22, 31, 43 };
            int[] arrSortedNoDuplicateRotate = { 2, 4, 6, 12, 15, 18, 22, 31, 43 };
            int[] rotateArr = { 5,6,7,9,15,1,2,4};
            int[][] matrixSortedNoDuplicate = { new int[] { 1, 3, 5, 7, 9 }, new int[] { 10, 12, 14, 16, 18 }, new int[] { 21, 23, 25, 27, 29 }, new int[] { 30, 32, 34, 36, 38 } };
            Ch2 ch2 = new Ch2();

            //Find K's closest element
            //int[] test = { 1, 10, 15, 25, 35, 45, 50, 59 };
            //Write(ch2.kClosestNumbers(test, 30, 7));
            //search range
            //Write(ch2.SearchRange(arrSortedDuplicate, 12));

            //Get Insert postion
            //Write(ch2.GetInsertPosition(arrSortedNoDuplicate, 12));

            //Search in matrix
            // Write(ch2.Search2DMatrixV2(matrixSortedNoDuplicate, 5));

            //Find Peak
            //Write(ch2.FindPeak(arrNoDuplicate));
            //Console.ReadKey();

            //Find Min in Rotate
            //Write(ch2.FindMinInRotate(rotateArr));
            //Console.ReadKey();

            //Find target in Rotate
            //Write(ch2.SearchInRotate(arrSortedNoDuplicateRotate,18));
            // Console.ReadKey();

            //Remove DuplicateII
            //Write(ch2.RemoveDuplicatedII(arrSortedDuplicate));
            #endregion

            #region CH3

            #region init
            TreeNode one = new TreeNode(1);
            TreeNode two = new TreeNode(2);
            TreeNode three = new TreeNode(3);
            TreeNode four = new TreeNode(4);
            TreeNode five = new TreeNode(5);
            TreeNode six = new TreeNode(6);
            TreeNode seven = new TreeNode(7);
            TreeNode eight = new TreeNode(8);
            TreeNode night = new TreeNode(9);
            TreeNode ten = new TreeNode(10);
            TreeNode eleven = new TreeNode(11);
            TreeNode twelve = new TreeNode(12);

            five.left = three;
            five.right = eight;

            three.left = one;
            three.right = four;

            eight.left = seven;
            eight.right = ten;

            seven.left = six;

            ten.left = night;
            ten.right = eleven;


            #endregion
            Ch3 ch3 = new Ch3();
            //eleven.right = twelve;
            // Write(ch3.isBalanced(five));
            //Write(ch3.GetMaxPath(five));
            // Write(ch3.FindLCA(five, eight, ten).val);
            // Write(ch3.SearchRange(five,4,10));
            //NodeIterator ni = new NodeIterator(five);
            //while (ni.hasNext())
            //{
            //    Write(ni.next().val);
            //}
            // five = ch3.DeleteNode(five, 11);
            // Write(ten.right.val);

            // Console.ReadKey();
            #endregion

            #region CH4
            ListNode n1 = new ListNode(4);
            ListNode n2 = new ListNode(7);
            ListNode n3 = new ListNode(7);
            ListNode n4 = new ListNode(10);
            ListNode n5 = new ListNode(12);
            ListNode n6 = new ListNode(12);
            ListNode n7 = new ListNode(25);
            ListNode n8 = new ListNode(36);
            ListNode n9 = new ListNode(48);
            Ch4 ch4 = new Ch4();
            //ListNode sorted = n1;  
            //{
            //    n1.next = n2;
            //    n2.next = n3;
            //    n3.next = n4;
            //    n4.next = n5;
            //    n5.next = n6;
            //    n6.next = n7;
            //    n7.next = n8;
            //    n8.next = n9;
            //}

            ListNode unSorted = n5;
            {
                n5.next = n7;
                n7.next = n4;
                n4.next = n8;
                n8.next = n2;
                n2.next = n3;
                n3.next = n9;
                n9.next = n1;
                n1.next = n6;

            }

            // Write(unSorted);
            // Write(ch4.Partition(unSorted,22));


            // 
            #endregion
            //Console.WriteLine("GetEnvironmentVariables: ");
            //foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
            //    Console.WriteLine("  {0} = {1}", de.Key, de.Value);
            #region leetcode
            Leetcode lc = new Leetcode();
            /*
              question 1
             */
            
            //int[] arr={3,2,4};
            //int[] result= lc.LeetCode1_TwoSum(arr, 6);
            /************************************************************************************/
            /*
             question 2
             */
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            ListNode node6 = new ListNode(6);
            ListNode node7 = new ListNode(7);
            ListNode node8 = new ListNode(8);
            ListNode node9 = new ListNode(9);

            node2.next = node4;
            node4.next = node3;
            node5.next = node6;
            node6.next = node1;
            //ListNode n = lc.AddTwoNumbers(node2, node5);
            /************************************************************************************/



    /*
     Question 3
     */
            //int result = lc.LengthOfLongestSubstring(test);
            //Write(result);
            
            //Console.ReadKey();
            
            //int  i=lc.FirstUniqChar("leetcode");
            //StringBuilder sb = new StringBuilder();
            //sb.Append('a');
            //sb.Append('e');
            //sb.Append('i');
            //sb.Append('o');
            //sb.Append('u');
            //Console.Write(sb.ToString()[0]);
            //Write(lc.RepeatedSubstringPattern(str));
            //int[,] arr = new int[4, 2];
            //int width = arr.GetLength(0);
            //int height = arr.GetLength(1);

            //bounds
            //int upperBound0 = arr.GetUpperBound(0);
            //int lowerBound0 = arr.GetLowerBound(0);
            //int upperBound1 = arr.GetUpperBound(1);
            //int lowerBound1 = arr.GetLowerBound(1);

            //Console.WriteLine("upper bound 0: " + upperBound0);
            //Console.WriteLine("lower bound 0: " + lowerBound0);
            //Console.WriteLine("upper bound 1: " + upperBound1);
            //Console.WriteLine("lower bound 1: " + lowerBound1);

           // Algrithms.QuickSort(arrNoDuplicate, 0, arrNoDuplicate.Length - 1);
            //Write(arrNoDuplicate);

            //int t = 122; long r = 0;
            //for (int i = 0; i < 50; i++)
            //{
            //    r = 31 * r + t;
            //}
            //Console.Write(r);
            //    Console.ReadKey();

            #region 5
            /*5*/

            //string str = "caba";
            //string sub = lc.LongestPalindromeSubstring(str);
            
            #endregion

            #region 7
            int ori=1534236469;
            int result = lc.ReverseInteger(ori);
            Console.Write(result);
            Console.ReadKey();
            #endregion
            #endregion
        }
            


        public static string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            string revstr = Reverse(s);
            string[] strArray = revstr.Split(' ');
            StringBuilder result = new StringBuilder();
            foreach (string str in strArray)
            {
                result.Append(Reverse(str));
                result.Append(" ");
            }
            return result.ToString().Trim();
        }
        private static string Reverse(string ori)
        {
            if (string.IsNullOrEmpty(ori))
                return ori;
            char[] result = new char[ori.Length];
            char[] oriArray = ori.ToCharArray();
            for (int i = ori.Length - 1; i >= 0; i--)
            {
                result[ori.Length - 1 - i] = oriArray[i];
            }
            return new string(result);
        }



        static void Write(int[] obj)
        {
            ArrayList al = new ArrayList();
            //al.Count();
            char[] arr = new char[10];
            string str = "test";
            arr[0] = str[3]; arr.Contains('3');
            for (int i = 0; i < obj.Length; i++)
            {
                
                Console.Write(obj[i] + " ");
            }
        }

        static void Write(int obj)
        {
            Console.Write(obj);
        }

        static void Write(bool obj)
        {
            if (obj)
                Console.Write("true");
            else
                Console.Write("false");
        }
        static void Write(ArrayList obj)
        {
            for (int i = 0; i < obj.Count; i++)
            {
                Console.Write(obj[i] + " ");
            }
        }

        static void Write(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
            Console.WriteLine();
        }
    }
    public class NodeIterator
    {
        TreeNode curt;
        Stack<TreeNode> s = new Stack<TreeNode>();

        public NodeIterator(TreeNode root)
        {
            curt = root;
        }
        public bool hasNext()
        {
            return curt != null || s.Count > 0;
        }

        public TreeNode next()
        {
            while (curt != null)
            {
                s.Push(curt);
                curt = curt.left;
            }
            curt = s.Pop();
            TreeNode node = curt;
            curt = curt.right;
            return node;
        }
    }
}
