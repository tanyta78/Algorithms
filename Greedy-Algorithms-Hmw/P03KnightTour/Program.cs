namespace P03KnightTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Cell> board;

        public static void Main(string[] args)
        {
            //Use Warnsdorff's rule to decide which cell the knight should visit next.

            var count = int.Parse(Console.ReadLine());

            board = new List<Cell>();

            for (int row = 1; row <= count; row++)
            {
                for (int col = 1; col <= count; col++)
                {
                    var cell = new Cell(row, col);
                    board.Add(cell);
                }
            }

            int moves = 1;
            var currentCell = board[0];
            currentCell.IsVisited = true;
            currentCell.TurnNumber = moves++;

            while (board.Any(c => !c.IsVisited))
            {
                currentCell = SelectNextCell(currentCell);
                currentCell.IsVisited = true;
                currentCell.TurnNumber = moves++;
            }

            PrintBoard(count);

        }

        private static void PrintBoard(int count)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Console.Write(board[i * count + j].TurnNumber.ToString().PadLeft(3) + " ");
                }
                Console.WriteLine();
            }
        }

        private static Cell SelectNextCell(Cell current)
        {
            var topLeft = board.FirstOrDefault(c => c.Row == current.Row - 2 && c.Col == current.Col - 1);
            var leftTop = board.FirstOrDefault(c => c.Row == current.Row - 1 && c.Col == current.Col - 2);
            var rightTop = board.FirstOrDefault(c => c.Row == current.Row - 1 && c.Col == current.Col + 2);
            var topRight = board.FirstOrDefault(c => c.Row == current.Row - 2 && c.Col == current.Col + 1);

            var bottomLeft = board.FirstOrDefault(c => c.Row == current.Row + 2 && c.Col == current.Col - 1);
            var leftBottom = board.FirstOrDefault(c => c.Row == current.Row + 1 && c.Col == current.Col - 2);
            var rightBottom = board.FirstOrDefault(c => c.Row == current.Row + 1 && c.Col == current.Col + 2);
            var bottomRight = board.FirstOrDefault(c => c.Row == current.Row + 2 && c.Col == current.Col + 1);

            var result = new List<Cell>
                        {
                            rightBottom,rightTop,leftBottom, leftTop, bottomRight, topRight, topLeft, bottomLeft
                        }
                        .Where(c => c != null && !c.IsVisited)
                        .ToList()
                        .OrderBy(c => KnightMoves(c))
                        .First();
            return result;
        }

        public static int KnightMoves(Cell current)
        {
            var topLeft = board.FirstOrDefault(c => c.Row == current.Row - 2 && c.Col == current.Col - 1);
            var leftTop = board.FirstOrDefault(c => c.Row == current.Row - 1 && c.Col == current.Col - 2);
            var rightTop = board.FirstOrDefault(c => c.Row == current.Row - 1 && c.Col == current.Col + 2);
            var topRight = board.FirstOrDefault(c => c.Row == current.Row - 2 && c.Col == current.Col + 1);

            var bottomLeft = board.FirstOrDefault(c => c.Row == current.Row + 2 && c.Col == current.Col - 1);
            var leftBottom = board.FirstOrDefault(c => c.Row == current.Row + 1 && c.Col == current.Col - 2);
            var rightBottom = board.FirstOrDefault(c => c.Row == current.Row + 1 && c.Col == current.Col + 2);
            var bottomRight = board.FirstOrDefault(c => c.Row == current.Row + 2 && c.Col == current.Col + 1);

            var result = new List<Cell>
                         {
                             topLeft, topRight, leftTop, rightTop, bottomLeft, bottomRight, leftBottom, rightBottom
                         }
                         .Where(c => c != null && !c.IsVisited).Count();
            return result;
        }

        public class Cell
        {
            public Cell(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row { get; set; }
            public int Col { get; set; }
            public bool IsVisited { get; set; }
            public int TurnNumber { get; set; }
        }
    }
}
