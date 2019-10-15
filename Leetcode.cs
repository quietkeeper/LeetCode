using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode;
using System.Collections;

namespace NCProjects
{
    class Leetcode
    {
        Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
        #region 1
        public int[] LeetCode1_TwoSum(int[] arr, int sum)
        {
            
            int[] result = new int[2] { -1, -1 };
            if (arr == null || arr.Length == 0)
                return result;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == sum)
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return result;
        }
        #endregion

        #region 2
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;
            else if (l1 == null)
                return l2;
            else if (l2 == null)
                return l1;
            else
            {
                ListNode temp = l2;
                int carry = 0;
                while (temp != null && l1 != null)
                {
                    temp.val = l1.val + temp.val + carry;
                    carry = temp.val / 10;
                    temp.val = temp.val % 10;
                    temp = temp.next;
                    l1 = l1.next;
                }
                if (l1 != null)
                    temp = l1;
                while (carry > 0 && temp != null)
                {
                    temp.val += carry;
                    carry = temp.val / 10;
                    temp.val = temp.val % 10;
                    temp = temp.next;
                }
                if (temp == null && carry > 0)
                {
                    temp = new ListNode(carry);
                }
                return l2;
            }
        }

        #endregion

        #region 3 Longest Substring Without Repeating Characters
        public int LengthOfLongestSubstring(string s) {
            if (string.IsNullOrEmpty(s))
                return -1;
            char[] char_Array = s.ToCharArray();
            HashSet<char> temp = new HashSet<char>();
            int max = 0;
            for (int i = 0; i < char_Array.Length; i++)
            {
                for (int j = i; j < char_Array.Length; j++)
                {
                    if (!temp.Contains(char_Array[j]))
                    {
                        temp.Add(char_Array[j]);
                    }
                    else
                    {
                        if (temp.Count > max)
                        {
                            max = temp.Count;
                        }
                        temp.Clear();
                        break;
                    }
                }
            }
            return max;
        }
        #endregion

        #region 5 LongestPalindrome substring
        public string LongestPalindromeSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            int max=0;
            string result=string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                string sub = GetPalindromeSub(s, i);
                if (sub.Length > max)
                {
                    max = sub.Length;
                    result = sub;
                }
            }
            return result;
        }

        public string GetPalindromeSub(string s, int starting)
        {
            int count1 = 0, count2 = 1;
            int preIndex=0,postIndex=0;
            for (int i = starting, pre = starting, post = starting + 1; i < s.Length && pre >= 0 && post < s.Length; i++, pre--, post++)
            {
                if (s[pre] == s[post])
                {
                    count1 += 2;
                    preIndex = pre;
                    postIndex = post;
                }
                else
                    break;

            }
            for (int i = starting, pre = starting-1, post = starting + 1; i < s.Length && pre >= 0 && post < s.Length; i++, pre--, post++)
            {
                if (s[pre] == s[post])
                {
                    count2 += 2;
                    if (count2 > count1)
                    {
                        preIndex = pre;
                        postIndex = post;
                    }

                }
                else
                    break;
            }
            return s.Substring(preIndex, postIndex - preIndex + 1);
        }
        #endregion
        
        #region 6
        public string StringConvert(string s, int numRows)
        {
            //if (s == null || s.Length == 0)
            //    return s;
            //if (numRows == 1)
            //    return s;
            //if (s.Length < numRows)
            //    return s;
            //StringBuilder sb = new StringBuilder();
            //int counter = numRows+1;
            //for (int i = 0; i < numRows; i++)
            //{
            //    counter -= 1;
            //    int index = i;
            //    while (index < s.Length && index >= 0&&index!=counter-1)
            //    {
            //        sb.Append(s[index]);
            //        if (counter > 0)
            //            index = index + (counter * 2 - 3)+1;
            //        else
            //            break;
            //    }
            //}
            //return sb.ToString();
            if (numRows == 1) return s;
            int x = 2 * (numRows - 1); // distance between pipes |/|/|...
            int len = s.Length;
            char[] c = new char[len];
            int k = 0;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = i; j < len; j = j + x)
                {
                    c[k++] = s[j];
                    if (i > 0 && i < numRows - 1 && j + x - 2 * i < len)
                    {
                        c[k++] = s[j + x - 2 * i]; // extra character between pipes
                    }
                }
            }
            return new String(c);
        }
        #endregion
        
        #region 7
        public int ReverseInteger(int ori) {
        Int32 result=0;
        try{
            while(ori!=0)
            {
                int temp=ori%10;
                
                result =checked( result * 10+temp);
                if (result > Int32.MaxValue || result < Int32.MinValue)
                    return 0;
                ori/=10;
            }
        }
        catch(Exception ex)
        {
            return 0;
        }
        
        return result;
        
    }
        #endregion

        #region 8
        public int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            string s = str.Trim();
            if (string.IsNullOrEmpty(s))
                return 0;
            bool isNagetive = s[0] == 45;
            bool hasSigned = isNagetive;
            int result = 0;
            try
            {
                for (int i = isNagetive ? 1 : 0; i < s.Length; i++)
                {
                    if (s[i] >= 48 && s[i] <= 57)
                        result = checked(result * 10 + (s[i] - 48));
                    else
                        if (s[i] == 43 && !hasSigned)
                        {
                            hasSigned = true;
                            continue;

                        }
                        else
                            break;
                }
                if (isNagetive)
                    result = result * -1;
            }
            catch (Exception ex)
            {
                if (isNagetive)
                    return Int32.MinValue;
                else
                    return Int32.MaxValue;
            }

            return result;
        }
        #endregion

        #region 9 Palindrome Number
        public bool IsPalindrome(int x)
        {
            if (x >= 0 && x < 10)
                return true;
            if (x < 0 || x % 10 == 0)
                return false;
            int xPrime = ReverseInteger(x);
            return xPrime == x;
        }
        #endregion

        #region 11 Container With Most Water
        public int MaxArea(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return 0;
            int max = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int value = (j - i) * (arr[i] < arr[j] ? arr[i] : arr[j]);
                    if (max < value)
                        max = value;
                }
            }
            return max;
        }
        #endregion

        #region 12 IntToRoman
        public string IntToRoman(int num)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1,"I");
            dict.Add(4, "IV");
            dict.Add(5, "V");
            dict.Add(9, "IX");
            dict.Add(10,"X");
            dict.Add(40, "XL");
            dict.Add(50,"L");
            dict.Add(90, "XC");
            dict.Add(100,"C");
            dict.Add(400, "CD");
            dict.Add(500,"D" );
            dict.Add(900, "CM");
            dict.Add(1000,"M");
            string result = string.Empty;
            foreach (var item in dict.OrderByDescending(x => x.Key))
            {
                
                int t = num / item.Key;
                while (t > 0)
                {
                    result = result + item.Value;
                    t--;
                }
                num = num % (item.Key);
            }
            return result;
        }
        #endregion 


        #region 13
        public int RomanToInt(string s)
        {
            int[] a = new int[26];
            a['I' - 'A'] = 1;
            a['V' - 'A'] = 5;
            a['X' - 'A'] = 10;
            a['L' - 'A'] = 50;
            a['C' - 'A'] = 100;
            a['D' - 'A'] = 500;
            a['M' - 'A'] = 1000;
            char prev = 'A';
            int sum = 0;
            foreach (char c in s.ToCharArray())
            {
                if (a[c - 'A'] > a[prev - 'A'])
                {
                    sum = sum - 2 * a[prev - 'A'];
                }
                sum = sum + a[c - 'A'];
                prev = c;
            }
            return sum;
        }
        #endregion

        #region 14. Longest Common Prefix
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return string.Empty;
            string common = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                if (common.Length == 0)
                    break;
                int j = 0;
                int shortest=Math.Min(common.Length,strs[i].Length);
                foreach (char c in strs[i])
                {
                    if (j<shortest&&c == common[j])
                        j++;
                    else
                    {
                        break;
                    }
                }
                common = common.Substring(0, j);

            }
            return common;
        }
        #endregion

        #region 15. 3Sum
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            //if (nums == null || nums.Length == 0)
            //    return null;
            throw new NotImplementedException();
        }
        #endregion
        #region 17. Letter Combinations of a Phone Number
        //public IList<string> LetterCombinations(string digits)
        //{
        //    if (string.IsNullOrEmpty(digits))
        //        return null;
        //    Dictionary<char, string> dict = new Dictionary<char, string>();
        //    dict.Add('2', "abc");
        //    dict.Add('3', "def");
        //    dict.Add('4', "ghi");
        //    dict.Add('5', "jkl");
        //    dict.Add('6', "mno");
        //    dict.Add('7', "pqrs");
        //    dict.Add('8', "tuv");
        //    dict.Add('9', "wxyz");
        //    ArrayList result = new ArrayList();
        //}
        #endregion
        #region 20. Valid Parentheses
        public bool IsValid(string str)
        {
            if (str == null || str.Length % 2 > 0)
                return false;
            Dictionary<char, char> dict = new Dictionary<char, char>();
            dict.Add('}', '{');
            dict.Add(']', '[');
            dict.Add(')', '(');

            Stack<char> s = new Stack<char>();
            foreach (var c in str)
            {
                if (dict.Values.Contains(c))
                    s.Push(c);
                if (dict.Keys.Contains(c))
                {
                    if (s.Count == 0)
                        return false;
                    char k = s.Pop();
                    if (dict[c] == k)
                        continue;
                    else
                        return false;
                }
            }
            return s.Count == 0;
        }
        #endregion
        #region 21
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            ListNode head = new ListNode(-100);
            ListNode temp=head;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    temp.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    temp.next = l2;
                    l2 = l2.next;
                }
                temp = temp.next;
            }
            if (l1 == null)
                temp.next = l2;
            else
                temp.next = l1;
            return head.next;
        }

        #endregion

        #region 27
        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int z = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                    z++;
                else
                {
                    if (z != val)
                        nums[i - z] = nums[i];
                }
            }
            for (int i = nums.Length - z; i < nums.Length; i++)
                nums[i] = val;
            return z;
        }
        #endregion

        #region 28
        public int StrStr(string haystack, string needle)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.OrderBy(x => x.Value);
            if (haystack == null || needle == null)
                return -1;
            if (needle.Length == 0)
                return 0;
            if (needle.Length > haystack.Length)
                return -1;
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                for (int j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                        break;
                    if (j == needle.Length - 1)
                        return i;
                }
            }
            return -1;
        }
        #endregion

        #region 53 Maximum Subarray
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return int.MinValue;

            int result = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                int tempSum = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (tempSum > result)
                        result = tempSum;
                    tempSum += nums[j];
                }
                if (tempSum > result)
                    result = tempSum;
            }
            return result;
        }

        public int MaxSub_Array(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return int.MinValue;
            if (arr.Length == 1)
                return arr[0];
            int result = GetMaxSub(arr,0,arr.Length-1);
            return result;

        }
        private int GetMaxSub(int[] arr, int start, int end)
        {
            if (arr.Length == 1)
                return arr[0];
            if (end < start)
                return int.MinValue;
            int medium = start + (end - start) / 2;
            int result = arr[medium];
            int lMax = GetMaxSub(arr, start, medium - 1);
            int rMax= GetMaxSub(arr, medium+1, end);
            int part = Math.Max(lMax, rMax);
            if (part > 0)
                return result + medium;
            else
                return result;
        }
        #endregion

        #region 70
        public int ClimbStairs(int n)
        {
            if (n <= 3)
                return n;

            //return ClimbStairs(n - 2) + ClimbStairs(n - 1);
            int[] temp = new int[n+1];
            temp[0] = 0;
            temp[1] = 1;
            temp[2] = 2;
            for (int i = 3; i < temp.Length; i++)
            {
                temp[i] = temp[i - 2] + temp[i - 1];
            }
            return temp[n];
        }
        #endregion

        #region 83
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;
            ListNode current = head;
            while (current.next != null)
            {
                if (current.val == current.next.val)
                    current.next = current.next.next;
                else
                    current = current.next;
            }
            return head;
        }
        #endregion

        #region 100
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (q == null && p == null)
                return true;
            else if (p == null || q == null)
                return false;
            bool result = IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right) && (p.val == q.val);
            return result;
        }
        #endregion

        #region 104
        public int GetMaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int l = 1, r = 1;
            if (root.left != null)
                l = GetMaxDepth(root.left);
            if (root.right != null)
                r = GetMaxDepth(root.right);
            return Math.Max(l + 1, r + 1);
        }
        #endregion

        #region 121
        public int MaxProfit(int[] prices)
        {
            //if (prices == null || prices.Length == 0)
            //    return 0;
            //int[] result = new int[prices.Length - 1];
            //for (int i = 0; i < prices.Length - 1; i++)
            //{
            //    int largest = Int32.MinValue;
            //    for (int j = i + 1; j < prices.Length; j++)
            //    {
            //        int profit = prices[j] - prices[i];
            //        if (profit > largest)
            //            largest = profit;
            //    }
            //    result[i] = largest;
            //}
            //int max=Int32.MinValue;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (result[i] > max)
            //        max = arr[i];
            //}
            //if (max <= 0)
            //    return 0;
            //return max;
            int maxCur = 0, maxSoFar = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                maxCur = Math.Max(0, maxCur += prices[i] - prices[i - 1]);
                maxSoFar = Math.Max(maxCur, maxSoFar);
            }
            return maxSoFar;
        }
        #endregion

        #region 146. LRU Cache

        public class LRUNode
        {
            public LRUNode pre;
            public LRUNode next;
            public int key;
            public int value;

            public LRUNode(int key, int value)
            {
                this.key = key;
                this.value = value;

                pre = null;
                next = null;
            }
        }
        public class LRUCache
        {

            public LRUCache(int capacity)
            {
                
            }

            public int Get(int key)
            {
                
                    
                return -1;
            }

            public void Put(int key, int value)
            {
               
            }
        }
        #endregion
        #region 168
        public string ConvertToTitle(int n)
        {
            if (n == 0)
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append(ConvertToTitle(n / 26)).Append((char)(n % 26 + 'A' - 1));

            return sb.ToString();
        }
        #endregion

        #region 169
        public int MajorityElement(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -100;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                    dict[nums[i]]++;
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            foreach (var d in dict)
            {
                if (d.Value > (nums.Length / 2))
                    return d.Key;
            }
            return -1;
        }
        #endregion

        #region 171

        public int TitleToNumber(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            int result = s[s.Length - 1] - 'A' + 1;
            for (int i = s.Length - 2; i >= 0; i--)
            {
                result += (int)Math.Pow(26, (s.Length - 2 - i)) * 26 * (s[i] - 'A');
            }
            return result;
        }
        #endregion

        #region 190
        public uint reverseBits(uint n)
        {
            uint result = 0;
            for (int i = 0; i < 32; i++)
            {
                uint temp = n & 1;
                n = n >> 1;
                result = result | temp;
                result = result << 1;
            }
            return result;
        }
        #endregion

        #region 191
        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n != 0)
            {
                count += (int)(n & 1);
                n = n >> 1;
            }
            return count;
        }
        #endregion

        #region 202
        public bool IsHappy(int n)
        {
            if (n <= 0)
                return false;
            int slow = n, fast = n;
            do
            {
                slow = GetSquareSum(slow);
                fast = GetSquareSum(fast);
                fast = GetSquareSum(fast);
            } while (slow != fast);
            if (slow == 1)
                return true;
            return false;
        }
        private int GetSquareSum(int num)
        {
            int sum = 0, temp;
            while (num != 0)
            {
                temp = num % 10;
                sum += temp * temp;
                num = num / 10;
            }
            return sum;
        }
        #endregion

        #region 204
        public int CountPrimes(int n)
        {
            if (n <= 1)
                return 0;
            int count = 0;//1
            for (int i = 2; i < n; i++)
            {
                bool isPrime = IsPrime(i);

                if (isPrime)
                    count++;
            }
            return count;
        }
        private bool IsPrime(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        #endregion

        #region 206
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            while (head.next != null)
            {
                ListNode temp = head.next;
                head.next = temp.next;
                temp.next = head;
                head = temp;
            }
            return head;
        }
        #endregion

        #region 217
        public bool ContainsDuplicate(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return false;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                        return true;
                }
            }
            return false;
        }
        #endregion

        #region 226
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            root.left = InvertTree(root.left);
            root.right = InvertTree(root.right);

            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;

            return root;
        }
        #endregion

        #region 231
        public bool IsPowerOfTwo(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count += n & 1;
                n = n >> 1;
            }
            if (count == 1)
                return true;
            else
                return false;
        }
        #endregion

        #region 235
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;
            if (root == p || root == q)
                return root;
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left == null)
                return right;
            else if (right == null)
                return left;
            else
                return root;
        }
        #endregion

        #region 237
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
        #endregion

        #region 242
        public bool IsAnagram(string s, string t)
        {
            if (s == null || t == null)
                return false;
            int[] arr = new int[128];
            for (int i = 0; i < s.Length; i++)
                arr[s[i]]++;
            for (int i = 0; i < t.Length; i++)
                arr[t[i]]--;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != 0)
                    return false;
            return true;
        }

        #endregion

        #region 263
        public bool IsUgly(int num)
        {
            if (num == 0)
                return false;
            if (num == 1)
                return true;
            num = GetOtherPrime(num);
            if (num == 1)
                return true;
            else
                return false;
        }

        private int GetOtherPrime(int n)
        {
            while (n % 2 == 0)
            {
                n = n / 2;
            }
            while (n % 3 == 0)
            {
                n /= 3;
            }
            while (n % 5 == 0)
                n /= 5;
            return n;
        }
        #endregion

        #region 283
        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;
            int z = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    z++;
                else
                {
                    if (z > 0)
                        nums[i - z] = nums[i];
                }
            }
            for (int i = nums.Length - z; i < nums.Length; i++)
                nums[i] = 0;
        }
        #endregion

        #region 292
        public int SingleNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }
            int rst = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                rst ^= nums[i];
            }
            return rst;
        }
        #endregion

        #region 297. Serialize and Deserialize Binary Tree
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            StringBuilder result = new StringBuilder();
            if (root == null)
                return "[]";
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            result.Append("[");
            while (q.Count > 0)
            {
                TreeNode temp = q.Dequeue();
                if (temp.val == Int32.MinValue)
                {
                    result.Append("null,");
                }
                else
                {
                    result.Append(temp.val + ",");
                    if (temp.left == null)
                        q.Enqueue(new TreeNode(Int32.MinValue) { });
                    else
                        q.Enqueue(root.left);
                    if (temp.right == null)
                        q.Enqueue(new TreeNode(Int32.MinValue) { });
                    else
                        q.Enqueue(root.right);
                    
                }
                
            }
            result.Remove(result.Length - 1, 1);
            result.Append("]");
            return result.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)||data=="null")
                return null;
            string[] d = data.Split(',');
            Queue<TreeNode> q = new Queue<TreeNode>();
            TreeNode root = new TreeNode(Convert.ToInt32(d[0]));
            q.Enqueue(root);
            int counter = 1;

            while (q.Count > 0)
            {
                TreeNode temp = q.Dequeue();
                if (counter >= d.Length)
                    break;
                if (d[counter] != "null")
                {
                    TreeNode left= new TreeNode(Convert.ToInt32(d[counter]));
                    temp.left = left;
                    q.Enqueue(left);
                }
                counter += 1;
                if (counter >= d.Length)
                    break;
                if (d[counter] != "null")
                {
                    TreeNode right = new TreeNode(Convert.ToInt32(d[counter]));
                    temp.right = right;
                    q.Enqueue(right);
                }
                counter += 1;
            }
            return root;
        }
        #endregion

        #region 303
        private int[] arr;
        //public Leetcode(int[] nums)
        //{

        //    for (int i = 1; i < nums.Length; i++)
        //        nums[i] += arr[i - 1];
        //    arr = nums;
        //}
        public int SumRange(int i, int j)
        {
            if (arr == null || arr.Length == 0)
                return Int32.MinValue;
            if (i < 0 || j >= arr.Length)
                return Int32.MinValue;
            if (i > j)
                return Int32.MinValue;
            if (i == 0)
                return arr[j];
            return arr[j] - arr[i - 1];
        }
        #endregion

        #region 326
        public bool IsPowerOfThree(int n)
        {
            if (n <= 0 || n % 3 != 0)
                return false;
            if (n == 1)
                return true;
            while (n > 1)
            {
                if (n % 3 != 0)
                    return false;
                n /= 3;
            }
            return true;
        }
        #endregion

        #region 342
        public bool IsPowerOfFour(int num)
        {
            if (num <= 0)
                return false;
            while (num % 4 == 0)
                num /= 4;
            if (num == 1)
                return true;
            return false;
        }
        #endregion

        #region 344
        public string ReverseString(string s)
        {
            char[] ch = s.ToCharArray();
            int head = 0, tail = ch.Length - 1;
            char temp;
            while (head < tail)
            {
                temp = ch[head];
                ch[head] = ch[tail];
                ch[tail] = temp;
                head++; tail--;
            }
            return new String(ch);
        }
        #endregion

        #region 349
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                return null;
            if (nums1.Length == 0 || nums2.Length == 0)
                return new int[0];
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!result.Contains(nums1[i]))
                {
                    for (int j = 0; j < nums2.Length; j++)
                    {
                        if (!result.Contains(nums2[j]) && (nums2[j] == nums1[i]))
                        {
                            result.Add(nums2[j]);
                            break;
                        }
                    }
                }
            }
            return result.ToArray();
        }
        #endregion

        #region 350
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                return null;
            Array.Sort(nums2);
            Array.Sort(nums1);
            List<int> intersect = new List<int>();

            int counter = 0; int i = 0, j = 0;
            for (; i < nums1.Length; i++)
                for (; j < nums2.Length; j++)
                {
                    if (nums2[j] == nums1[i])
                    {
                        intersect.Add(nums1[i]);
                        j++;
                        break;
                    }
                    else if (nums2[j] > nums1[i])
                        break;
                }
            int[] result = new int[intersect.Count];
            foreach (int v in intersect)
                result[counter++] = v;
            return result;
        }
        #endregion
        #region 366. Find Leaves of Binary Tree
        public int DsfTranverse(TreeNode root, Dictionary<int,List<TreeNode>> dict)
        {
            if (root == null)
                return 0;
            int depth = Math.Max(DsfTranverse(root.left, dict), DsfTranverse(root.right, dict)) + 1;
            if (!dict.ContainsKey(depth))
                dict.Add(depth, new List<TreeNode>());
            dict[depth].Add(root);
            root.left = null;
            root.right = null;
            return depth;
        }
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;
            Dictionary<int, List<TreeNode>> dict = new Dictionary<int, List<TreeNode>>();
            int maxDepth = DsfTranverse(root, dict);
            for (int i = 1; i <= maxDepth; i++)
            {
                List<int> leafs = new List<int>();
                foreach (var n in dict[i])
                    leafs.Add(n.val);
                result.Add(leafs);
            }
            return result;
        }
        #endregion
        #region 383
        public bool CanConstruct(string ransomNote, string magazine)
        {

            if (magazine == null || magazine.Length == 0 || ransomNote == null || ransomNote.Length == 0 || (magazine.Length < ransomNote.Length))
                return false;
            int[] arr = new int[26];
            for (int i = 0; i < magazine.Length; i++)
                arr[magazine[i] - 97]++;
            for (int i = 0; i < ransomNote.Length; i++)
                arr[ransomNote[i] - 97]--;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] < 0)
                    return false;
            return true;
        }

        #endregion

        #region 387
        public int FirstUniqChar(string s)
        {
            if (s == null || s.Length == 0)
                return -1;
            int[] nums = new int[128];
            char[] uniq = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                nums[(int)s[i]]++;
            }
            int counter = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                    uniq[counter++] = (char)i;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (uniq.Contains(s[i]))
                    return i;
            }
            return -1;
        }

        #endregion

        #region 389
        public char FindTheDifference(string s, string t)
        {
            int[] chars = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                chars[s[i] - 97] += 1;
            }
            for (int i = 0; i < t.Length; i++)
            {
                chars[t[i] - 97] -= 1;
            }
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] < 0)
                    return (char)(i + 97);
            }
            return 'N';
        }
        #endregion

        #region 401
        public IList<string> ReadBinaryWatch(int num)
        {
            if (num < 0)
                return null;
            List<string> result = new List<string>();
            for (int h = 0; h < 12; h++)
                for (int m = 0; m < 60; m++)
                {
                    if (CountBit(h * 64) + CountBit(m) == num)
                        result.Add(h.ToString("D") + ":" + m.ToString("D2"));
                }
            return result;
        }
        private int CountBit(int num)
        {
            int count = 0;
            while (num != 0)
            {
                count += num & 1;
                num = num >> 1;
            }
            return count;
        }
        #endregion

        #region 404
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
                return 0;
            int result = 0;

            if (root.left != null && (root.left.left == null && root.left.right == null))
            {
                result = SumOfLeftLeaves(root.right) + root.left.val;
                return result;
            }
            result = SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);

            return result;
        }
        #endregion

        #region 405
        public string ToHex(int num)
        {
            if (num == 0)
                return "0";
            StringBuilder sb = new StringBuilder();
            //do
            //{
            //    int temp = num & 15;
            //    temp += temp > 10 ? ('a' - 10) : '0';
            //    sb.Append((char)temp);
            //} while (num >> 4 != 0);
            //return sb.ToString();
            string dict = "123456789abcdef";
            do
            {
                int temp = num & 15;
                sb.Append(dict[temp]);
            } while (num >> 4 > 0);
            return sb.ToString();
        }
        #endregion

        #region 409
        public int LongestPalindrome(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                    dict[s[i]]++;
                else
                    dict.Add(s[i], 1);
            }
            int count = 0;
            bool hasOdd = false;
            foreach (var d in dict)
            {
                if (d.Value % 2 == 0)
                    count += d.Value;
                else
                {
                    count += (d.Value - 1);
                    hasOdd = true;

                }
            }
            if (hasOdd)
                count += 1;
            return count;
        }
        #endregion

        #region 412
        public List<string> FizzBuzz(int n)
        {
            if (n == 0)
                return null;
            List<string> result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                {
                    result.Add(i.ToString());
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    if (i % 3 == 0)
                        sb.Append("Fizz");
                    if (i % 5 == 0)
                        sb.Append("Buzz");
                    result.Add(sb.ToString());
                }
            }
            return result;
        }
        #endregion

        #region 414
        public int ThirdMax(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return Int32.MinValue;
            int first = Int32.MinValue, second = Int32.MinValue, third = Int32.MinValue, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > first)
                {
                    count++;
                    third = second;
                    second = first;
                    first = nums[i];
                }
                else if (nums[i] != first)
                    continue;
                else if (nums[i] > second)
                {
                    third = second;
                    second = nums[i];
                    count++;
                }

                else if (nums[i] >= third)
                {
                    third = nums[i];
                    count++;
                }
            }
            if (count < 3)
                return first;
            else
                return third;
        }
        #endregion

        #region 415
        public string AddStrings(string num1, string num2)
        {
            if (num1 == null)
                return num2;
            if (num2 == null)
                return num1;
            StringBuilder sb = new StringBuilder();
            int carry = 0;
            for (int i = num1.Length - 1, j = num2.Length - 1; i <= 0 || j <= 0 || carry > 0; i--, j--)
            {
                int v1 = i < 0 ? 0 : num1[i] - '0';
                int v2 = j < 0 ? 0 : num2[j] - '0';
                sb.Append((v1 + v2 + carry) % 10);
                carry = (v1 + v2 + carry) / 10;
            }

            string result = sb.ToString();

            return ReverseString(result);
        }


        #endregion

        #region 434
        public int CountSegments(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ' && start == end)
                    start++;
                if (s[i] == ' ' && start != end)
                    end++;
            }
            return start;
        }
        #endregion

        #region 453
        public int MinMoves(int[] nums)
        {

            if (nums == null || nums.Length == 0 || nums.Length == 1)
                return 0;
            Array.Sort(nums);
            if (nums[0] == nums[nums.Length - 1])
                return 0;
            else
            {
                int count = 0;
                for (int i = 1; i < nums.Length; i++)
                {

                    if (nums[i - 1] != nums[i])
                        count++;
                }
                return (count - 1) + nums[nums.Length - 1] - nums[0];
            }


            //int step = 0;
            //while (1 != 0)
            //{
            //    bool equal = true;
            //    int big = 0;
            //    for (int i = 1; i < nums.Length; i++)
            //    {
            //        if (nums[big] != nums[i])
            //        {
            //            equal=false;
            //            if (nums[big] < nums[i])
            //                big = i;
            //        }
            //    }

            //    if (equal)
            //        break;
            //    nums[big]--;
            //    step++;
            //}
            //return step;
        }
        #endregion

        #region 455
        public int FindContentChildren(int[] g, int[] s)
        {
            if (g == null || g.Length == 0)
                return 0;
            if (s == null || s.Length == 0)
                return 0;

            Array.Sort(g);
            Array.Sort(s);
            int result = 0;

            for (int i = 0, j = 0; i < g.Length && j < s.Length; )
            {
                if (g[i] <= s[j])
                {
                    result += 1;
                    i++; j++;
                }
                else
                    j++;
            }
            return result;
        }
        #endregion

        #region 459
        public bool RepeatedSubstringPattern(string str)
        {
            for (int i = 1; i <= str.Length / 2; i++)
            {
                if (str[i] == str[0])
                {
                    if (CheckRepeat(str, str.Substring(0, i)))
                        return true;
                }
            }
            return false;
        }

        private bool CheckRepeat(string ori, string sub)
        {
            if (ori.Length % sub.Length != 0)
                return false;
            int counter = 0;
            for (int i = 0; i < ori.Length; i++)
            {
                if (ori[i] != sub[i - (sub.Length * counter)])
                    return false;
                if (counter < ((i + 1) / sub.Length))
                    counter++;
            }
            return true;
        }
        #endregion

        #region 463
        public int IslandPerimeter(int[][] grid)
        {
            if (grid == null || (grid.Length == 0) || (grid[0] == null) || (grid[0].Length == 0))
            {
                return 0;
            }
            int result = 0;
            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        if ((i - 1 < 0) || (grid[i - 1][j] == 0))
                            result += 1;
                        if ((i + 1 >= grid.Length) || (grid[i + 1][j] == 0))
                            result += 1;
                        if ((j - 1 < 0) || (grid[i][j - 1] == 0))
                            result += 1;
                        if ((j + 1 >= grid[0].Length) || (grid[i][j + 1] == 0))
                            result += 1;
                    }
                }
            return result;
        }

        public int IslandPerimeter(int[,] grid)
        {
            if (grid == null || (grid.GetLength(0) == 0) || (grid.GetLength(1) == 0))
            {
                return 0;
            }
            int result = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 1)
                    {
                        if ((i - 1 < 0) || (grid[i - 1, j] == 0))
                            result += 1;
                        if ((i + 1 >= grid.GetLength(0)) || (grid[i + 1, j] == 0))
                            result += 1;
                        if ((j - 1 < 0) || (grid[i, j - 1] == 0))
                            result += 1;
                        if ((j + 1 >= grid.GetLength(1)) || (grid[i, j + 1] == 0))
                            result += 1;
                    }
                }
            return result;
        }
        #endregion

        #region 654. Maximum Binary Tree
        public TreeNode ConstructMaximumBinaryTree(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return null;
            TreeNode root = MaxTree(arr, 0, arr.Length - 1);
            return root;
        }
        private TreeNode MaxTree(int[] arr, int start, int end)
        {
            if (start >end)
                return null;
            int maxPosition = GetMaxPosition(arr, start, end);
            TreeNode root = new TreeNode(arr[maxPosition]);
            
            root.left = MaxTree(arr, start, (maxPosition - 1));
            root.right= MaxTree(arr, (maxPosition + 1), end);
            return root;
        }
        private int GetMaxPosition(int[] arr,int start, int end)
        {
            if (start >= arr.Length || end < 0 )
                return -1;
            int max = int.MinValue, pointer = 0 ;
            for (int i = start; i <= end ; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    pointer = i;
                }
            }
            return pointer;
        }
        #endregion

        #region 807. Max Increase to Keep City Skyline
        public int MaxIncreaseKeepingSkyline(int[][] arr)
        {
            if (arr == null || arr.Length == 0 || arr[0].Length == 0)
                return -1;
            int[][] skylines = GetSkylines(arr);

            int difference = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[0].Length; j++)
                {
                    int minLine = Math.Min(skylines[0][i], skylines[1][j]);
                    if (arr[i][j] < minLine)
                        difference += minLine - arr[i][j];
                }
            }
            return difference;
        }
        private int[][] GetSkylines(int[][] arr)
        {
            int[][] result = new int[2][];
            result[0] = new int[arr.Length];
            result[1] = new int[arr[0].Length];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[0].Length; j++)
                {
                    if (result[0][i] < arr[i][j])// horizontal
                        result[0][i] = arr[i][j];
                    if (result[1][j] < arr[i][j])// vertical
                        result[1][j] = arr[i][j];
                }
            }
            return result;
        }


        #endregion

        #region 896
        public bool IsMonotonic(int[] arr) {
            if (arr == null || arr.Length == 0)
                return false;
            if (arr.Length == 1)
                return true;
            bool isMonotonic = true;
            int monotonic = 0;//0 no value, 1 increase, 2 decrease
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (monotonic == 0)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        monotonic = 2;
                    }
                    else if (arr[i] < arr[i + 1])
                        monotonic = 1;
                    continue;
                }
                else if (monotonic == 1)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        isMonotonic = false;
                        break;
                    }
                }
                
                else
                {
                    if (arr[i] < arr[i + 1])
                    {
                        isMonotonic = false;
                        break;
                    }
                    
                }
            }
            return isMonotonic;
        }
        #endregion

        #region 1038. Binary Search Tree to Greater Sum Tree
        int GetSum(TreeNode root)
        {
            if (root == null)
                return 0;
            int sum = GetSum(root.left) + GetSum(root.right) + root.val;
            return sum;
        }
        int DSF_InOrder(TreeNode root, int sum)
        {
            if (root == null)
                return 0;
            int oldVal = root.val;
            int leftVal = DSF_InOrder(root.left, sum);
            
            root.val = sum-leftVal;
            leftVal += oldVal;
            int rightVal= DSF_InOrder(root.right, sum - leftVal);
            return leftVal+rightVal;
        }
        public TreeNode BstToGst(TreeNode root)
        {
            if (root == null)
                return null;
            int sum = GetSum(root);
            DSF_InOrder(root, sum);
            return root;
        }
        #endregion
    }
    class BinarySearch
    {
        public int ClosestNumberInSortedArray(int target, int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;
            int start = 0, end = arr.Length - 1;
            while (start < end - 1)
            {
                int mid = start + (end - start) / 2;
                if (arr[mid] == target)
                    return mid;
                if (arr[mid] > target)
                    end = mid;
                else
                    start = mid;
            }
            if (Math.Abs(arr[start] - target) < Math.Abs(arr[end] - target))
                return start;
            else
                return end;
        }
    }
}
