namespace ConnectingCables
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int[,] possibleCounts;

        public static void Main(string[] args)
        {
            var cablesPermutation = Console.ReadLine()
                                           .Split(' ')
                                           .Select(int.Parse)
                                           .ToArray();
            var cablesOrdered = cablesPermutation.OrderBy(c => c).ToArray();

            int result = FindMaxConnections(cablesPermutation, cablesOrdered);

            Console.WriteLine($"Maximum pairs connected: {result}");
        }

        private static int FindMaxConnections(int[] side1, int[] side2)
        {
            int length = side1.Length;
            possibleCounts = new int[length + 1, length + 1];

            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= length; j++)
                {
                    if (side1[i - 1] == side2[j - 1])
                    {
                        possibleCounts[i, j] = possibleCounts[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        possibleCounts[i, j] = Math.Max(possibleCounts[i - 1, j], possibleCounts[i, j - 1]);
                    }
                }
            }

            return possibleCounts[length, length];
        }
    }
}
