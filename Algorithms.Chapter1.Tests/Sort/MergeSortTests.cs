﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Sort;

namespace Algorithms.Part1.Tests.Sort
{
    public class MergeSortTests
    {
        [Fact]
        public void Sort_EmptyArray_ReturnsEmptyArr()
        {
            // Arrange
            int[] input = new int[0];
            int[] expectedOutput = new int[0];
            MergeSort mergeSort = new MergeSort();

            // Act
            int[] actualOutput = mergeSort.Sort(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Sort_OneElementArray_ReturnsOneElement()
        {
            // Arrange
            int[] input = new int[1] { 1 };
            int[] expectedOutput = new int[1] { 1 };
            MergeSort mergeSort = new MergeSort();

            // Act
            int[] actualOutput = mergeSort.Sort(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Sort_TwoElementUnsortedArray_ReturnsSortedArr()
        {
            // Arrange
            int[] input = new int[2] { 5, 1 };
            int[] expectedOutput = new int[2] { 1, 5 };
            MergeSort mergeSort = new MergeSort();

            // Act
            int[] actualOutput = mergeSort.Sort(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Sort_OddNumberOfElementsUnsortedArray_ReturnsSortedArr()
        {
            // Arrange
            int[] input = new int[5] { -5, -7, 0, 38, 2 };
            int[] expectedOutput = new int[5] { -7, -5, 0, 2, 38 };
            MergeSort mergeSort = new MergeSort();

            // Act
            int[] actualOutput = mergeSort.Sort(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Sort_EvenNumberOfElementsUnsortedArray_ReturnsSortedArr()
        {
            // Arrange
            int[] input = new int[6] { -5, -7, 0, 38, 2, 3 };
            int[] expectedOutput = new int[6] { -7, -5, 0, 2, 3, 38 };
            MergeSort mergeSort = new MergeSort();

            // Act
            int[] actualOutput = mergeSort.Sort(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Sort_ArrayWithRepeatingValues_ReturnsSortedArr()
        {
            // Arrange
            int[] input = new int[6] { 0, -5, 0, 3, 2, 3 };
            int[] expectedOutput = new int[6] { -5,0,0,2,3,3};
            MergeSort mergeSort = new MergeSort();

            // Act
            int[] actualOutput = mergeSort.Sort(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

    }
}
