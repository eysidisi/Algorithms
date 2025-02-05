﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Sort.QuickSortAlgorithm
{
    public class HelperMethods
    {
        /// <summary>
        /// Returns the index of the pivot after the sort
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="leftIndex"></param>
        /// <param name="rightIndex"></param>
        /// <param name="pivotIndex"></param>
        /// <returns></returns>
        public int PartitionArr(ref int[] arr, int leftIndex, int rightIndex, int pivotIndex)
        {
            Swap(ref arr, pivotIndex, leftIndex);

            int pivotVal = arr[leftIndex];

            int followingIndex = leftIndex + 1;

            // Find first element larger than pivot val
            while (followingIndex <= rightIndex)
            {
                if (arr[followingIndex] > pivotVal)
                {
                    break;
                }
                followingIndex++;
            }

            for (int leadingIndex = followingIndex + 1; leadingIndex <= rightIndex; leadingIndex++)
            {
                if (pivotVal > arr[leadingIndex])
                {
                    Swap(ref arr, followingIndex, leadingIndex);
                    followingIndex++;
                }
            }

            Swap(ref arr, followingIndex - 1, leftIndex);
            return followingIndex - 1;
        }

        public void Swap(ref int[] arr, int index1, int index2)
        {
            int temp = arr[index2];
            arr[index2] = arr[index1];
            arr[index1] = temp;
        }

    }
}
