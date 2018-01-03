using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCProjects
{
    public class Lintcode
    {
        #region 1

        /// <summary>
        /// Given a mountain sequence of n integers which increase firstly and then decrease, find the mountain top.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindMountainTop(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;
            int start = 0, end = arr.Length - 1;
            while (start < end - 1)
            {
                int mid = start + (end - start) / 2;
                if (mid > 0 && mid < (arr.Length - 1))
                {
                    if (arr[mid] < arr[mid - 1])
                        end = mid;
                    else if (arr[mid] < arr[mid + 1])
                        start = mid;
                    else
                        return arr[mid];
                }
            }
            if (arr[start] > arr[end])
                return arr[start];
            else
                return arr[end];
        }
        #endregion
    }
}
