using LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace NCProjects
{
    class Helper
    {
        
        public static int GetSteps(int p, int[] c)
        {
            int min = Int32.MaxValue;
            if (p + 2 < c.Length)
            {
                if (c[p + 1] == 1)
                    min = 1 + GetSteps(p + 2, c);
                else if (c[p + 2] == 1)
                    min = 1 + GetSteps(p + 1, c);
                else
                {
                    int s1= 1 + GetSteps(p + 1, c);
                    int s2= 1 + GetSteps(p + 2, c);
                    min = Math.Min(s1, s2);
                }
                return min;
            }
            else if (p + 1 < c.Length)
                return 1;
            else
                return 0;
        }
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

        public static void swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static int getMaxOccurrences(string s, int minLength, int maxLength, int maxUnique)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            Dictionary<string, int> numArray = GetDuplicateSubString(s, minLength, maxLength, maxUnique);
            return numArray.Values.Max();
        }
        private static Dictionary<string, int> GetDuplicateSubString(string s, int minLength, int maxLength, int maxUnique)
        { 

            Dictionary<string,int> result=new Dictionary<string, int>();

            for(int i=0;i<s.Length-minLength;i++)
            {
                for (int j = i + 1; j < s.Length - minLength; j++)
                {
                    int tempi = i, tempj = j,unique=0;
                    while (s[tempi] == s[tempj])
                    {
                        if (tempi - i == minLength)
                        {
                            string r = s.Substring(i, tempi);
                            if (!result.Keys.Contains(r))
                                result.Add(r, 1);
                            else
                                result[r] += 1;
                            break;
                        }
                           
                        if (unique > maxUnique)
                            break;
                        tempi++;
                        tempj++;
                    }
                }
            }
            return result;
        }
        //private static int GetDuplicateStr(int character,List<int> positions,string s, int minLength, int maxLength, int maxUnique)
        //{
        //    int[] UniqCounters=new int[positions.Count];
        //    int repeatCounter = positions.Count;
        //    for (int i = 0; i < positions.Count; i++)
        //    {
        //        for (int j = 1; j < minLength; j++)
        //        { 
        //            if(s.Substring(positions[0]))
        //        }
        //    }
        //}
    }
}
