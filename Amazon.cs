using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Amazon
    {
        #region Valid Parentheses
        public bool ValidParentheses(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            if (str.Length % 2 == 1)
                return false;
            Stack<char> s = new Stack<char>();
            String LEFTPARENTHESES = "[{(";
            foreach (char c in str)
            {
                if (LEFTPARENTHESES.Contains(c))
                    s.Push(c);
                if (s.Count == 0)
                    return false;
                else if (IsPair(s.Peek(), c))
                    s.Pop();
            }
            return s.Count == 0;

        }
        private bool IsPair(char left, char right)
        {
            switch (left)
            {
                case '{':
                    if (right == '}')
                        return true;
                    else
                        return false;
                case '[':
                    if (right == ']')
                        return true;
                    else
                        return false;
                case '(':
                    if (right == ')')
                        return true;
                    else
                        return false;
                default:
                    return false;
            }
        }
        #endregion

        #region rectangle overlap
        public bool IsOverlap(Point lt1, Point rb1, Point lt2, Point rb2)
        {
            if (lt1.X > rb2.X || rb1.X < lt2.X || lt1.Y < rb2.Y || rb1.Y > lt2.Y)
                return false;
            else
                return true;

        }
        #endregion

        #region window sum
        public int[] WindowSum(int[] arr, int windowSize)
        {
            if (arr == null || arr.Length == 0 || windowSize == 0 || windowSize > arr.Length)
                return null;
            int[] result = new int[arr.Length - windowSize + 1];
            for (int i = 0; i < arr.Length - windowSize; i++)
            {
                int sum = 0;
                for (int j = i; j < windowSize + i; j++)
                {
                    sum += j;
                }
                result[i] = sum;
            }

            for (int i = 0; i < windowSize; i++)
                result[0] += arr[i];
            for (int i = 1; i < arr.Length - windowSize; i++)
            {
                result[i] = result[i - 1] - arr[i - 1] + arr[i + windowSize - 1];
            }

            /*
             public int[] winSum(int[] nums, int k) {
        // write your code here
        if (nums == null || nums.length < k || k <= 0)
            return new int[0];

        int[] sums = new int[nums.length - k + 1];
        for (int i = 0; i < k; i++)
            sums[0] += nums[i];
        for (int i = 1; i < sums.length; i++) {
            sums[i] = sums[i - 1] - nums[i - 1] + nums[i + k-1];
        }
        return sums;
             */
            return result;

        }
        #endregion

        #region course schedule
        public int[] findOrder(int numCourses, int[][] prerequisites)
        {
            // Write your code here
            ArrayList[] edges = new ArrayList[numCourses];
            int[] degree = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
                edges[i] = new ArrayList();

            for (int i = 0; i < prerequisites.Length; i++)
            {
                degree[prerequisites[i][0]]++;
                edges[prerequisites[i][1]].Add(prerequisites[i][0]);
            }

            Queue queue = new Queue();
            for (int i = 0; i < degree.Length; i++)
            {
                if (degree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            int count = 0;
            int[] order = new int[numCourses];
            while (queue.Count != 0)
            {
                int course = (int)queue.Dequeue();
                order[count] = course;
                count++;
                int n = edges[course].Count;
                for (int i = n - 1; i >= 0; i--)
                {
                    int pointer = (int)edges[course][i];
                    degree[pointer]--;
                    if (degree[pointer] == 0)
                    {
                        queue.Enqueue(pointer);
                    }
                }
            }

            if (count == numCourses)
                return order;

            return new int[0];
        }
        #endregion

        #region nearest k points
        /*
         We have a list of points on the plane.  Find the K closest points to the origin (0, 0).

        (Here, the distance between two points on a plane is the Euclidean distance.)

        You may return the answer in any order.  The answer is guaranteed to be unique (except for the order that it is in.)
         */
        public int[][] KClosest(int[][] points, int K)
        {
            if (points == null || points[0] == null)
                return null;
            if (points.Length < K)
                return points;
            Dictionary<int, double> distance = new Dictionary<int, double>();
            for (int i = 0; i < points.Length; i++)
            {
                distance.Add(i, Math.Pow(points[i][0], 2) + Math.Pow(points[i][1], 2));
            }
            int[] ps = distance.OrderBy(x => x.Value).Take(K).Select(x => x.Key).ToArray();
            int[][] result = new int[K][];
            for (int i = 0; i < K; i++)
            {
                result[i] = points[ps[i]];
            }
            return result;

        }
        #endregion

        #region Merge Two Sorted Lists
        //public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        //{
        //    if (l1 == null)
        //        return l2;
        //    if (l2 == null)
        //        return l1;
        //    ListNode current = l1;
        //    ListNode head=l1;

        //    if (l1.val <= l2.val)
        //    {
        //        head = l1;
        //        current=l1;
        //    }
        //    else
        //    {
        //        head = l2;
        //        current=l2;
        //    }
        //    while (l1.next != null && l2.next != null)
        //    {
        //        if (l1.val <= l2.val)
        //        {
        //            current = l1;
        //            l1 = l1.next;
        //            current.next=

        //        }
        //    }
        //}
        #endregion

        #region Quick sort and Quick select
        public void QuickSort(int[] A, int left, int right)
        {
            if (left > right || left < 0 || right < 0) return;

            int index = partition(A, left, right);

            if (index != -1)
            {
                QuickSort(A, left, index - 1);
                QuickSort(A, index + 1, right);
            }
        }

        //public int QuickSelect(int[] arr, int left, int right,int k)
        //{
        //    if (left > right)
        //        return -1;
        //    if (k > right - left + 1)
        //    {
        //        return -1;
        //    }
        //    int result = int.MinValue;
        //    int pivot = partition(arr, left, right);
        //    if (pivot-left == k-1)
        //        return arr[pivot];
        //    else if (pivot - left > k - 1)//arr, index + 1, r, k - index + l - 1
        //        result=QuickSelect(arr, pivot+1, right, k - pivot+left-1);
        //    else
        //        result= QuickSelect(arr, left, pivot-1, k);
        //    return result;
        //}

        private int partition(int[] A, int left, int right)
        {
            if (left > right) return -1;

            int index = left;

            int pivot = A[right];    // choose last one to pivot, easy to code
            for (int i = left; i < right; i++)
            {
                if (A[i] <=pivot)
                {
                    swap(A, i, index);
                    index++;
                }
            }

            swap(A, index, right);

            return index;
        }

        private void swap(int[] A, int left, int right)
        {
            int tmp = A[left];
            A[left] = A[right];
            A[right] = tmp;
        }
        #endregion

        #region min cost construct
        class Connetction
        {
            public int City1 { get; set; }
            public int City2 { get; set; }
            public int Cost { get; set; }

            public Connetction(int city1,int city2,int cost)
            {
                City1 = city1;
                City2 = city2;
                Cost = cost;
            }

        }
        class UnionFind
        {
            private int[] cities;
            public UnionFind(int all)
            {
                cities = new int[all + 1];
                for (int i = 0; i < all + 1; i++)
                {
                    cities[i] = i;
                }
            }

            public int Root(int i)
            {
                while(cities[i] != i)
                    i = cities[i];
                return i;
            }

            public bool Find(int c1, int c2)
            {
                return Root(c1) == Root(c2);
            }

            public void Union(int c1, int c2)
            {
                int r1 = Root(c1);
                int r2 = Root(c2);

                cities[r1] = r2;
            }
        }
        int GetMinCostToConstruct( int numTotalAvailableCities,
                                   int numTotalAvailableRoads,
                                   List<List<int>> roadsAvailable,
                                   int numNewRoadsConstruct,
                                   List<List<int>> costNewRoadsConstruct
                                 )
        {
            if (numTotalAvailableCities <2 || numTotalAvailableRoads>=numTotalAvailableCities-1)
                return 0;
            UnionFind uf = new UnionFind(numTotalAvailableCities);

            int avblRdCnt = 0;

            foreach (List<int> r in roadsAvailable)
            {
                int c1 = r[0];
                int c2 = r[1];

                if (!uf.Find(c1, c2))
                {
                    uf.Union(c1, c2);
                    avblRdCnt++;
                }
            }
            HashSet<Connetction> connection_hs = ListToHashsetConverter(costNewRoadsConstruct);

            ArrayList mst = new ArrayList();
            connection_hs.OrderBy(x => x.Cost);
            while (connection_hs.Count > 0 && mst.Count + avblRdCnt < numTotalAvailableCities - 1)
            {
                Connetction temp = connection_hs.FirstOrDefault();
                int c1 = temp.City1;
                int c2 = temp.City2;
                if (!uf.Find(c1, c2))
                {
                    uf.Union(c1, c2);
                    mst.Add(temp);
                }
                connection_hs.Remove(temp);
            }
            if (mst.Count + avblRdCnt < numTotalAvailableCities - 1)
                return -1;
            int sum = 0;
            foreach (Connetction c in mst)
                sum += c.Cost;
            return sum;
        
        }
        private HashSet<Connetction> ListToHashsetConverter(List<List<int>> roads)
        {
            if (roads == null)
                return null;
            HashSet<Connetction> result = new HashSet<Connetction>();
            foreach (List<int> r in roads)
            {
                result.Add(new Connetction(r[0], r[1], r[2]));
            }
            return result;
        }
        #endregion

      

    }
}
