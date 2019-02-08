namespace MoveDownRightSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int[,] matrix;
        private static int[,] sums;

        public static void Main(string[] args)
        {
            //Given a matrix of N by M cells filled with positive integers, find the path from top left to bottom right with a highest sum of cells by moving only down or right.

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            ReadMatrix(rows, cols);
            FillSumsMatrix(rows, cols);
            PrintPath(rows - 1, cols - 1);
        }

        private static void PrintPath(int row, int col)
        {
            var path = new List<string>();
            while (row + col > 0)
            {
                if (col == 0)
                {
                    path.Add($"[{row--}, {col}]");
                    continue;
                }

                if (row == 0)
                {
                    path.Add($"[{row}, {col--}]");
                    continue;
                }

                if (sums[row, col - 1] >= sums[row - 1, col])
                {
                    path.Add($"[{row}, {col--}]");
                }
                else
                {
                    path.Add($"[{row--}, {col}]");
                }
            }

            path.Add($"[{row}, {col}]");
            path.Reverse();

            Console.WriteLine(string.Join(" ", path));
        }

        private static void FillSumsMatrix(int rows, int cols)
        {
            sums = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var maxPrevSum = int.MinValue;

                    if (col > 0 && sums[row, col - 1] > maxPrevSum)
                    {
                        maxPrevSum = sums[row, col - 1];
                    }

                    if (row > 0 && sums[row - 1, col] > maxPrevSum)
                    {
                        maxPrevSum = sums[row - 1, col];
                    }

                    sums[row, col] = matrix[row, col];

                    if (maxPrevSum != int.MinValue)
                    {
                        sums[row, col] += maxPrevSum;
                    }
                }
            }
        }

        private static void ReadMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var currentRowElements = Console.ReadLine()
                                                .Split(' ')
                                                .Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRowElements[col];
                }
            }
        }
    }
}
