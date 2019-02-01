namespace _06P_ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static char[,] matrix;
        private static SortedSet<Area> areas = new SortedSet<Area>();
        private const char Wall = '*';
        private const char Visited = 'v';


        public static void Main(string[] args)
        {
            ReadMatrix();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    FindConnectedArea(row, col);
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");
            int counter = 1;
            foreach(var area in areas)
            {
                Console.WriteLine($"Area #{counter++} at ({area.Row}, {area.Col}), size: {area.Size}");
            }

        }

        private static void FindConnectedArea(int row, int col)
        {
            if (matrix[row, col] == Wall || 
                matrix[row, col] == Visited)
            {
                return;
            }
            var area = new Area(row, col);
            TraverseArea(row, col, area);

            areas.Add(area);
        }

        private static void TraverseArea(int row, int col, Area area)
        {
            if (!IsInBounds(row, col) ||
                matrix[row, col] == Wall ||
                matrix[row, col] == Visited)
            {
                return;
            }

            matrix[row, col] = Visited;
            area.Size++;

            TraverseArea(row, col + 1, area);
            TraverseArea(row + 1, col, area);
            TraverseArea(row, col - 1, area);
            TraverseArea(row - 1, col, area);
        }

        private static bool IsInBounds(int row, int col)
        {
            return row >= 0 &&
                   col >= 0 &&
                   row < matrix.GetLength(0) &&
                   col < matrix.GetLength(1);
        }

        private static void ReadMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }
        
        public class Area : IComparable<Area>
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public int Size { get; set; }

            public Area()
            {

            }

            public Area(int row, int col)
            {
                this.Row = row;
                this.Col = col;
                this.Size = 0;
            }

            public int CompareTo(Area other)
            {
                var cmp = other.Size.CompareTo(this.Size);
                if (cmp == 0)
                {
                    cmp = this.Row.CompareTo(other.Row);
                    if (cmp == 0)
                    {
                        cmp = this.Col.CompareTo(other.Col);
                    }
                }

                return cmp;
            }
        }
    }
}
