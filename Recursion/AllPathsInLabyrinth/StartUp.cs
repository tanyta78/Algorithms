using System;
using System.Collections.Generic;

namespace AllPathsInLabyrinth
{
    public class StartUp
    {
        static List<char> path = new List<char>();

        static char[,] lab =
            {
                {'-', '-', '-', '*', '-', '-', '-'},
                {'*', '*', '-', '*', '-', '*', '-'},
                {'-', '-', '-', '-', '-', '-', '-'},
                {'-', '*', '*', '*', '*', '*', '-'},
                {'-', '-', '-', '-', '-', '-', 'e'},
            };



        public static void Main()
        {
            FindPaths(0, 0, 's');
        }

        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsValidCell(row, col))
            {
                return;
            }
           
            path.Add(direction);

            if (lab[row, col] == 'e')
            {
                PrintPath();
            }
            else if (lab[row, col] != 'v')
            {
                lab[row, col] = 'v';

                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');

                lab[row, col] = '-';

            }
            path.RemoveAt(path.Count - 1);

        }

        private static void PrintPath()
        {

            Console.WriteLine(string.Join("", path));
        }

        private static bool IsValidCell(int row, int col)
        {
            return row >= 0 &&
                row < lab.GetLength(0) &&
                col >= 0 &&
                col < lab.GetLength(1) &&
                lab[row, col] != '*';
        }
    }
}
