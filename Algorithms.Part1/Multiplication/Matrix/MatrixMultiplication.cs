﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Multiplication.Matrix
{
    public class MatrixMultiplication
    {
        public int[,] BruteForce(int[,] matA, int[,] matB)
        {
            int numOfRows = matA.GetLength(0);
            int numOfCols = matB.GetLength(1);

            int[,] result = new int[matA.GetLength(0), matB.GetLength(1)];

            for (int rowIndex = 0; rowIndex < numOfRows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < numOfCols; colIndex++)
                {
                    result[rowIndex, colIndex] = MatrixMultiplicationHelperMethods.CalculateValueAtPosition(rowIndex, colIndex, matA, matB);
                }
            }

            return result;
        }

        //        Strassen(Very High-Level Description)
        //        Input: n ⇥ n integer matrices X and Y.
        //        Output: Z = X · Y.
        //        Assumption: n is a power of 2.
        //        if n = 1 then 
        //          return the 1 ⇥ 1 matrix with entry X[1][1] · Y[1][1]
        //        else // recursive case
        //          A, B, C, D := submatrices of X 
        //          E,F,G,H := submatrices of Y 
        //          recursively compute seven(cleverly chosen) products involving A,B, . . . ,H
        //          return the appropriate(cleverly chosen) additions 
        //          and subtractions of the matrices computed in the
        //          previous step

        //        P1 = A · (F −H)
        //        P2 = (A + B) ·H
        //        P3 = (C + D) · E
        //        P4 = D · (G− E)
        //        P5 = (A + D) · (E +H)
        //        P6 = (B − D) · (G+H)
        //        P7 = (A − C) · (E + F).

        //       First quadrant P5 + P4 + P6 − P2 
        //       Second quadrant P1 + P2
        //       Third quadrant P3 + P4
        //       Fourth quadrant P1 + P5 − P3 − P7

        public int[,] StrassenAlgorithm(int[,] matA, int[,] matB)
        {

            if (matA.Length == 1 && matB.Length == 1)
            {
                return new int[,] { { matA[0, 0] * matB[0, 0] } };
            }

            int[,] A = MatrixMultiplicationHelperMethods.FirstQuadrantOfMatrix(matA);
            int[,] B = MatrixMultiplicationHelperMethods.SecondQuadrantOfMatrix(matA);
            int[,] C = MatrixMultiplicationHelperMethods.ThirdQuadrantOfMatrix(matA);
            int[,] D = MatrixMultiplicationHelperMethods.FourthQuadrantOfMatrix(matA);

            int[,] E = MatrixMultiplicationHelperMethods.FirstQuadrantOfMatrix(matB);
            int[,] F = MatrixMultiplicationHelperMethods.SecondQuadrantOfMatrix(matB);
            int[,] G = MatrixMultiplicationHelperMethods.ThirdQuadrantOfMatrix(matB);
            int[,] H = MatrixMultiplicationHelperMethods.FourthQuadrantOfMatrix(matB);

            var FMinusH = MatrixMultiplicationHelperMethods.SubtractMatrices(F, H);
            var P1 = StrassenAlgorithm(A, FMinusH);

            var APlusB = MatrixMultiplicationHelperMethods.SumMatrices(A, B);
            var P2 = StrassenAlgorithm(APlusB, H);

            var CPlusD = MatrixMultiplicationHelperMethods.SumMatrices(C, D);
            var P3 = StrassenAlgorithm(CPlusD, E);

            var GMinusE = MatrixMultiplicationHelperMethods.SubtractMatrices(G, E);
            var P4 = StrassenAlgorithm(D, GMinusE);

            var APlusD = MatrixMultiplicationHelperMethods.SumMatrices(A, D);
            var EPlusH = MatrixMultiplicationHelperMethods.SumMatrices(E, H);
            var P5 = StrassenAlgorithm(APlusD, EPlusH);

            var BMinusD = MatrixMultiplicationHelperMethods.SubtractMatrices(B, D);
            var GPlusH = MatrixMultiplicationHelperMethods.SumMatrices(G, H);
            var P6 = StrassenAlgorithm(BMinusD, GPlusH);

            var AMinusC = MatrixMultiplicationHelperMethods.SubtractMatrices(A, C);
            var EPlusF = MatrixMultiplicationHelperMethods.SumMatrices(E, F);
            var P7 = StrassenAlgorithm(AMinusC, EPlusF);

            // First quadrant P5 + P4 + P6 − P2 
            var P5PlusP4 = MatrixMultiplicationHelperMethods.SumMatrices(P5, P4);
            var P6MinusP2 = MatrixMultiplicationHelperMethods.SubtractMatrices(P6, P2);
            var resultMatrixFirstQuadrant = MatrixMultiplicationHelperMethods.SumMatrices(P5PlusP4, P6MinusP2);

            // Second quadrant P1 + P2
            var resultMatrixSecondQuadrant = MatrixMultiplicationHelperMethods.SumMatrices(P1, P2);

            // Third quadrant P3 + P4
            var resultMatrixThirdQuadrant = MatrixMultiplicationHelperMethods.SumMatrices(P3, P4);

            // Fourth quadrant P1 + P5 − P3 − P7
            var P1PlusP5 = MatrixMultiplicationHelperMethods.SumMatrices(P1, P5);
            var P3PlusP7 = MatrixMultiplicationHelperMethods.SumMatrices(P3, P7);
            var reslutMatrixFourthQuadrant = MatrixMultiplicationHelperMethods.SubtractMatrices(P1PlusP5, P3PlusP7);

            int[,] resultMatrix = MatrixMultiplicationHelperMethods.FormResultantMatrix(resultMatrixFirstQuadrant, resultMatrixSecondQuadrant, resultMatrixThirdQuadrant, reslutMatrixFourthQuadrant);

            return resultMatrix;
        }

    }
}
