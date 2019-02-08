namespace RodCutting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static int[] prices;
        static int[] bestPrice;
        static int[] bestIndex;

        public static void Main(string[] args)
        {
            //Find the best way to cut up a rod with a specified length. You are also given to prices of all possible lengths starting from 0.

            prices = Console.ReadLine()
                                 .Split(' ')
                                 .Select(int.Parse)
                                 .ToArray();
            var rodLength = int.Parse(Console.ReadLine());
            bestPrice = new int[prices.Length];
            bestIndex = new int[prices.Length];

            PrintSolutionRecursive(rodLength);

           //PrintSolution(rodLength);
        }

        private static void PrintSolutionRecursive(int rodLength)
        {
            int bestWay = CutRodRecursive(rodLength);
            var result = new List<int>();

            while (rodLength > 0)
            {
                int next = bestIndex[rodLength];
                result.Add(next);
                rodLength -= next;
            }

            Console.WriteLine(bestWay);
            Console.WriteLine(String.Join(" ", result));
        }

        private static void PrintSolution(int rodLength)
        {
            int bestWay = CutRod(rodLength);
            var result = new List<int>();

            while (rodLength > 0)
            {
                int next = bestIndex[rodLength];
                result.Add(next);
                rodLength -= next;
            }

            Console.WriteLine(bestWay);
            Console.WriteLine(String.Join(" ", result));
           
        }

        private static int CutRod(int rodLength)
        {
            if (rodLength == 0)
            {
                return 0;
            }

            for (int i = 1; i <= rodLength; i++)
            {
                int currentBest = bestPrice[i];

                for (int j = 1; j <= i; j++)
                {
                    currentBest =
                        Math.Max(bestPrice[i], prices[j] + bestPrice[i - j]);
                    if (currentBest > bestPrice[i])
                    {
                        bestPrice[i] = currentBest;
                        bestIndex[i] = j;
                    }
                }
            }

            return bestPrice[rodLength];
        }

        private static int CutRodRecursive(int length)
        {
            if (bestPrice[length] != 0)
            {
                return bestPrice[length];
            }

            if (length == 0)
            {
                return 0;
            }

            int currentBest = 0;
            int wholePart = length;

            for (int i = 1; i <= length; i++)
            {
                int currentPrice = prices[i] + CutRodRecursive(length - i);

                if (currentPrice > currentBest)
                {
                    wholePart = i;
                    currentBest = currentPrice;
                }
            }

            bestIndex[length] = wholePart;
            bestPrice[length] = currentBest;
            return bestPrice[length];
        }
    }
}
