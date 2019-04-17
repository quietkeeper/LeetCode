using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCProjects
{
    class Ch2
    {
        public int[] SearchRange(int[] arr, int target)
        {
            int[] result = { -1, -1 };
            if (arr == null || arr.Length == 0)
                return result;
            int start = 0, end = arr.Length - 1;
            int mid;
            while (start < end - 1)
            {
                mid = start + (end - start) / 2;
                if (arr[mid] == target)
                    end = mid;
                else if (arr[mid] < target)
                    start = mid;
                else
                    end = mid;
            }
            if (arr[start] == target)
                result[0] = start;
            else if (arr[end] == target)
                result[0] = end;
            else
                return result;
            start = 0;
            end = arr.Length - 1;
            while (start < end - 1)
            {
                mid = start + (end - start) / 2;
                if (arr[mid] == target)
                    start = mid;
                else if (arr[mid] < target)
                    start = mid;
                else
                    end = mid;
            }
            if (arr[end] == target)
                result[1] = end;
            else if (arr[start] == target)
                result[1] = start;

            return result;
        }

        public int GetInsertPosition(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
                return -1;
            int start = 0, end = arr.Length - 1, mid;
            while (start < end - 1)
            {
                mid = start + (end - start) / 2;
                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] < target)
                    start = mid;
                else
                    end = mid;
            }
            if (arr[start] >= target)
                return start;
            else if (arr[end] >= target)
                return end;
            else
                return end + 1;
        }

        public bool Search2DMatrix(int[][] m, int target)
        {
            if (m == null || m.Length == 0)
                return false;
            int mid,start = 0, end = m.Length - 1;
            int row;
            while (start < end - 1)
            {
                mid = start + (end - start) / 2;
                if (m[mid][0] == target)
                    return true;
                else if (m[mid][0] < target)
                    start = mid;
                else
                    end = mid;
            }
            if (m[start][0] == target || m[end][0] == target)
                return true;
            else if (m[end][0] < target)
                row = end;
            else if (m[start][0] < target)
                row = start;
            else
                return false;
            start = 0;
            end = m[row].Length - 1;
            if (m[row] == null || m[row].Length == 0)
                return false;
            while (start < end - 1)
            {
                mid = start + (end - start) / 2;
                if (m[row][mid] == target)
                    return true;
                else if (m[row][mid] < target)
                    start = mid;
                else
                    end = mid;
            }
            if (m[row][start] == target)
                return true;
            else if (m[row][end] == target)
                return true;
            else
                return false;

        }

        public bool Search2DMatrixV2(int[][] m, int target)
        {
            if (m == null || m.Length == 0 || m[0] == null || m[0].Length == 0)
            {
                return false;
            }
            int start = 0, end = m.Length * m[0].Length - 1;
            int mid,rowMid,columnMid;
            while (start < end - 1)
            {
                mid = start + (end - start) / 2;
                rowMid = mid / m[0].Length;
                columnMid = mid % m[0].Length;
                if (m[rowMid][columnMid] == target)
                    return true;
                else if (m[rowMid][columnMid] < target)
                    start = mid;
                else
                    end = mid;
            }
            rowMid = start / m[0].Length;
            columnMid = start % m[0].Length - 1;

            if (m[rowMid][columnMid] == target)
                return true;
            else
            {
                rowMid = end / m[0].Length;
                columnMid = end % m[0].Length - 1;

                if (m[rowMid][columnMid] == target)
                    return true;
                else
                    return false;
            }
        }

        public int FindPeak(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;
            int start = 0, mid, end = arr.Length - 2;// 1.答案在之间，2.不会出界 
            while (start < end - 1)
            {
                mid = (end + start) / 2;
                if (arr[mid] < arr[mid - 1])
                    end = mid;
                else if (arr[mid] < arr[mid + 1])
                    start = mid;
                else
                    return mid;
            }
            if (arr[end] > arr[start])
                return end;
            else
                return start;
        }

        public int SearchInRotate(int[] arr,int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }
            int start = 0, end = arr.Length - 1;
            while (start < end - 1)
            {
                int mid = start + (end - start) / 2;
                if (arr[mid] == target)
                    return mid;
                if (arr[start] > arr[mid])
                {
                    if (arr[end] >= target && arr[mid] < target)//[5,1,3] , target : 5 case for the importance of the '>='
                        start = mid;
                    else
                        end = mid;
                }
                else
                {
                    if (arr[mid] > target && arr[start] <= target)//[1,3,5], target : 1 case for the importance of the '<='
                        end = mid;
                    else
                        start = mid;
                }
            }
            if (arr[start] == target)
                return start;
            else if (arr[end] == target)
                return end;
            else
                return -1;


            //int start = 0, end = arr.Length - 1;
            while (start < end - 1)
            {
                int mid = start + (end - start) / 2;
                if (arr[mid] == target)
                    return mid;
                if (arr[start] > arr[mid])
                {
                    if (arr[start] > target && arr[mid] < target)
                        start = mid;
                    else
                        end = mid;
                }
                else
                {
                    if (arr[mid] > target && arr[start] <= target)
                        end = mid;
                    else
                        start = mid;
                }
            }
            if (arr[start] == target)
                return start;
            else if (arr[end] == target)
                return end;
            else
                return -1;
        }
        public int FindMinInRotate(int[] arr)//error
        { 
            if((arr==null)||(arr.Length==0))
                return -1;
            int start = 0, end = arr.Length - 1;
            int mid = 0;
            while (start < end - 1)
            {
                mid = (start + end) / 2;
                if (arr[mid] < arr[end])
                    end = mid;
                else
                {
                    start = mid;
                }
            }
            if (arr[start] < arr[end])
                return start;
            else
                return end;
        }

        public int RemoveDuplicatedII(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }
            int size = 0, counter = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[size] == arr[i])
                {
                    counter++;
                    if (counter < 2)
                    {
                        arr[++size] = arr[i];
                    }
                }
                else
                {
                    counter = 0;
                    arr[++size] = arr[i];
                }
            }

            return size + 1;
        }

        public int[] kClosestNumbers(int[] arr, int target, int k)
        {
            if (arr == null || arr.Length <= 1 || k > arr.Length)
                return arr;
            int closest = closestNumber(arr, target);
            int[] result = new int[k];
            result[0] = arr[closest];
            int offsetL = 1, offsetR = 1;
            for (int i = 1; i < k; i++)
            {
                if (closest - offsetL >= 0 && closest + offsetR <= arr.Length - 1)
                {
                    if (Math.Abs(arr[closest - offsetL] - target) <= Math.Abs(arr[closest + offsetR] - target))
                    {
                        result[i] = arr[closest - offsetL];
                        offsetL++;
                    }
                    else
                    {
                        result[i] = arr[closest + offsetR];
                        offsetR++;
                    }
                }
                else if (closest - offsetL >= 0)
                {
                    result[i] = arr[closest - offsetL];
                    offsetL++;
                }
                else if (closest + offsetR <= arr.Length - 1)
                {
                    result[i] = arr[closest + offsetR];
                    offsetR++;
                }
                else
                    break;
            }
            return result;
        }
        public int closestNumber(int[] A, int target)
        {
            if (A == null || A.Length == 0)
            {
                return -1;
            }

            int start = 0, end = A.Length - 1;
            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;
                if (A[mid] == target)
                {
                    return mid;
                }
                else if (A[mid] > target)
                {
                    end = mid;
                }
                else
                {
                    start = mid;
                }

            }
            if (A[end] - target >= target - A[start])
                return start;
            else
                return end;
        }
    }
}
