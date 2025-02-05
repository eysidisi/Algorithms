﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Multiplication.Matrix;

namespace Algorithms.Part1.Tests.Multiplication.Matrix
{
    public class MatrixMultiplicationTests
    {
        [Fact]
        public void BruteForce_SquareMatrices()
        {
            // Arrange
            MatrixMultiplication matrixMultiplication = new MatrixMultiplication();

            var mat1 = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            var mat2 = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            var expectedOutput = new int[,]
            {
                { 30 ,36 ,42 },
                { 66 ,81 ,96 },
                { 102,126,150 }
            };

            // Act
            var actualOutput = matrixMultiplication.BruteForce(mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void BruteForce_MatricesWithDifferentDimension()
        {
            // Arrange
            MatrixMultiplication matrixMultiplication = new MatrixMultiplication();

            var mat1 = new int[,]
            {
                { 1, 2, 3},
                { 4, 5, 6 }
            };

            var mat2 = new int[,]
            {
                { 1, 2},
                { 3, 4},
                { 5, 6 }
            };

            var expectedOutput = new int[,]
            {
                { 22 , 28 },
                { 49 , 64 }
            };

            // Act
            var actualOutput = matrixMultiplication.BruteForce(mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void StrassenAlgorithm_MultiplyOneByOneMatrices()
        {
            // Arrange
            MatrixMultiplication matrixMultiplication = new MatrixMultiplication();

            var mat1 = new int[,]
            {
                {1}
            };

            var mat2 = new int[,]
            {
                {13}
            };

            var expectedOutput = new int[,]
            {
                { 13}
            };

            // Act
            var actualOutput = matrixMultiplication.StrassenAlgorithm(mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void StrassenAlgorithm_MultiplyTwoByTwoMatrices()
        {
            // Arrange
            MatrixMultiplication matrixMultiplication = new MatrixMultiplication();

            var mat1 = new int[,]
            {
                { 1,2},
                { 3,4}
            };

            var mat2 = new int[,]
            {
                { 5,6},
                { 7,8}
            };

            var expectedOutput = new int[,]
            {
                { 19,22},
                { 43,50}
            };

            // Act
            var actualOutput = matrixMultiplication.StrassenAlgorithm(mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void StrassenAlgorithm_MultiplyFourByFourMatrices()
        {
            // Arrange
            MatrixMultiplication matrixMultiplication = new MatrixMultiplication();

            var mat1 = new int[,]
            {
                { 1,2,3,4},
                { 5,6,7,8},
                { 9,10,11,12},
                { 13,14,15,16}
            };

            var mat2 = new int[,]
            {
                { 0,1,2,3},
                { 4,5,6,7},
                { 8,9,10,11},
                { 12,13,14,15}
            };

            var expectedOutput = new int[,]
            {
                { 80,   90, 100, 110},
                { 176, 202, 228, 254},
                { 272, 314, 356, 398},
                { 368, 426, 484, 542},

            };

            // Act
            var actualOutput = matrixMultiplication.StrassenAlgorithm(mat1, mat2);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
