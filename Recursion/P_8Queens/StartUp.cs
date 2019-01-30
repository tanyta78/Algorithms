namespace P_8Queens
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const int Size = 8;
        static bool[,] board = new bool[Size, Size];
        private static int solutionsFound = 0;

        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void Main()
        {
            PlaceQueen(0);
           // Console.WriteLine(solutionsFound);
        }

        private static void PlaceQueen(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
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
            attackedRightDiagonals.Remove(row - col);
        }

        private static void Mark(int row, int col)
        {
            board[row, col] = true;
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(row + col);
            attackedRightDiagonals.Add(row - col);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return !attackedRows.Contains(row) &&
                   !attackedCols.Contains(col) && 
                   !attackedLeftDiagonals.Contains(row + col) && 
                   !attackedRightDiagonals.Contains(row - col);
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Console.Write(board[row, col] ? "* " : "- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            solutionsFound++;
        }
    }
}
