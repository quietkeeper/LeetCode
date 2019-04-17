using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCProjects;

namespace LeetCode
{
    class Algrithms
    {
        public static void QuickSort(int[] arr, int start, int end)
        {
            if (arr == null || arr.Length == 0)
                return;
            if (start >= end)
                return;
            int left = start;
            int right = end;
            int pivot = arr[left + 1];
            while (left <= right)
            {
                while (left <= right && arr[left] < pivot)
                    left++;
                while (left <= right && arr[right] > pivot)
                    right--;
                if (left <= right)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }
            }
            QuickSort(arr, start, right);
            QuickSort(arr, left, end);
        }

       
    }
}
