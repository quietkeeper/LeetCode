﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class HackerRank
    {
        #region Minimum Swaps 2
        static int minimumSwaps(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;
            int result = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minLocation = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[minLocation] > arr[j])
                    {
                        minLocation = j;
                    }
                }
                if (minLocation != i)
                {
                    swap(ref arr[i], ref arr[minLocation]);

                    result += 1;
                }
                
            }
            return result;

        }

        private static void swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

        }
        #endregion

        #region minmaxsum
        static void miniMaxSum(int[] arr)
        {
            int[] boundries = GetBoundries(arr);
            foreach (int b in boundries)
            {
                long result = b*-1;
                foreach (int a in arr)
                {
                    result += a;
                }
                Console.Write(result);
            }
        }
        private static int[] GetBoundries(int[] arr)
        {
            int max = Int32.MinValue;
            int min = Int32.MaxValue;
            foreach(int v in arr)
            {
                if (max < v)
                    max = v;
                if (min > v)
                    min = v;
            }
            return new int[] { max, min };
        }
        #endregion

        #region staircase
        static void staircase(int n)
        {
            string space = " ";
            string pound = "#";
            int spaceCounter = 0;
            for (int i = n-1; i >= 0; i--)
            {
                spaceCounter = i;
                for (int j = 0; j < spaceCounter; j++)
                    Console.Write(space);
                for (int j = 0; j < n - spaceCounter; j++)
                    Console.Write(pound);
                Console.WriteLine();
            }

        }
        #endregion
        #region Plus Minus
        static void plusMinus(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return;
            }
            double[] result = GetRatio(arr);
            foreach (double r in result)
            {
                Console.WriteLine(r.ToString("N6"));
            }

        }
        static double[] GetRatio(int[] arr)
        {
            double resultPositive = 0;
            double resultNegative = 0;
            double resultZero = 0;
            int NumPositive = 0;
            int NumNegative = 0;
            int NumZero = 0;

            foreach (int i in arr)
            {
                if (i > 0)
                    NumPositive += 1;
                else if (i < 0)
                    NumNegative += 1;
                else
                    NumZero += 1;
            }
            resultPositive = NumPositive * 1.0 / (arr.Length);
            resultNegative= NumNegative * 1.0 / (arr.Length);
            resultZero=NumZero * 1.0 / (arr.Length);
            return new double[]{ resultPositive, resultNegative, resultZero };
        }
        #endregion
        #region Diagonal Difference
        static int diagonalDifference(int[][] arr)
        {
            if (arr == null || arr.Length == 0)
                return 0;
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int end = arr.Length - 1 - i;
                result += (arr[i][i] - arr[end][end]);
            }
            result = Math.Abs(result);
            return result;
        }

        #endregion
        #region New Year Chaos
        static void minimumBribes(int[] q)
        {
            if (q == null || q.Length == 0)
                return;
            Console.WriteLine(GetMinBribes(q));

        }
        static string GetMinBribes(int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {

                if (arr[i] - (i + 1) > 2)
                    return "Too chaotic";
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                        result += 1;
                }
            }

            return result.ToString();
        }
        #endregion
        #region Arrays: Left Rotation
        static int[] rotLeft(int[] arr, int d)
        {
            int[] result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                int index = i - d;
                if (index < 0)
                    index = arr.Length + index;
                result[index] = arr[i];
            }
            return result;
        }

        #endregion

        #region 2D Array - DS
        public static int hourglass(int[][] arr, int h, int v)
        {
            int result = 0;
            if ((h <= arr.Length - 3) && (v <= arr[0].Length - 3))
            {
                for (int i = h; i <= h + 2; i++)
                {
                    if (i - h == 1)
                    {
                        result += arr[i][v + 1];
                    }
                    else
                        for (int j = v; j <= v + 2; j++)
                        {
                            result += arr[i][j];
                        }
                }
            }
            return result;
        }
        static int hourglassSum(int[][] arr)
        {
            int result = Int32.MinValue;
            for (int i = 0; i <= arr.Length - 3; i++)
            {
                for (int j = 0; j <= arr[0].Length - 3; j++)
                    result = Math.Max(result, hourglass(arr, i, j));
            }
            return result;
        }
        #endregion

        #region Two Strings
        static string twoStrings(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return "No";
            if (HasCommon(s1, s2))
                return "Yes";
            else
                return "No";
        }
        private static bool HasCommon(string s1, string s2)
        {
            //foreach (char c in s2)
            //{
            //    if (s1.Contains(c))
            //        return true;
            //}
            int[] arr = new int[128];
            foreach (char c in s1)
            {
                arr[(int)c] += 1;
            }
            foreach (char c in s2)
            {
                if (arr[(int)c] > 0)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
