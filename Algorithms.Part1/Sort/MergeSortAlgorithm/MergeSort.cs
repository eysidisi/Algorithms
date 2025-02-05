﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Sort.MergeSortAlgorithm
{
    public class MergeSort
    {

        /// <summary>
        /// MergeSort
        /// Implements the sorting algorithm that's given below
        /// Input: array A of n distinct integers.
        /// Output: array with the same integers, sorted from smallest to largest.
        /// ignoring base cases
        /// C := recursively sort first half of A
        /// D := recursively sort second half of A
        /// return Merge (C, D)
        /// </summary>
        /// <param name="unsortedArr"></param>
        /// <returns></returns>
        public int[] Sort(int[] unsortedArr)
        {

            if (unsortedArr.Length <= 1)
            {
                return unsortedArr;
            }

            int[] firstPartOfArr = MergeSortHelperMethods.GetArrFirstPart(unsortedArr);
            firstPartOfArr = Sort(firstPartOfArr);

            int[] secondPartOfArr = MergeSortHelperMethods.GetSecondPart(unsortedArr);
            secondPartOfArr = Sort(secondPartOfArr);

            int[] mergedArr = MergeSortHelperMethods.MergeSortedArrays(firstPartOfArr, secondPartOfArr);

            return mergedArr;
        }
    }
}
