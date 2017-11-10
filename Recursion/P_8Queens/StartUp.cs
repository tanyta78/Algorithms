namespace P_8Queens
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static bool[,] board = new bool[8, 8];

        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRigthDiagonals = new HashSet<int>();
        private static int count;

        public static void Main()
        {
            PlaceQueen(0);
            Console.WriteLine(count);
        }

        private static void PlaceQueen(int row)
        {
            if (row == 8)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < 8; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        Mark(row, col);
                        PlaceQueen(row + 1);
                        Unmark(row, col);
                    }
                }

            }
        }

        private static void Unmark(int row, int col)
        {
            board[row, col] = false;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(row + col);
            attackedRigthDiagonals.Remove(row - col);
        }

        private static void Mark(int row, int col)
        {
            board[row, col] = true;
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(row + col);
            attackedRigthDiagonals.Add(row - col);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return !attackedRows.Contains(row) && !attackedCols.Contains(col) && !attackedLeftDiagonals.Contains(row + col) && !attackedRigthDiagonals.Contains(row - col);
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            count++;
        }
    }
}
