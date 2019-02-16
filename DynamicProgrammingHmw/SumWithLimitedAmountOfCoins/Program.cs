namespace SumWithLimitedAmountOfCoins
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int[] coins;

        private static long[,] memo;

        public static void Main(string[] args)
        {
            coins = Console.ReadLine()
                               .Split(' ')
                               .Select(int.Parse)
                               .ToArray();
            var sum = int.Parse(Console.ReadLine());
            var coinsNumber = coins.Length;
            memo = new long[coinsNumber + 1, sum + 1];

            FindAllPossibleSums(sum, coinsNumber);

            int count = 0;
            for (int i = 0; i <= coins.Length; i++)
            {
                if (memo[i, sum] != 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);

        }

        private static void FindAllPossibleSums(int sum, int coinsNumber)
        {
            for (int row = 0; row <= coinsNumber; row++)
            {
                memo[row, 0] = 1;
            }

            for (int row = 1; row <= coinsNumber; row++)
            {
                var currentCoin = coins[row - 1];
                for (int currentSum = sum; currentSum >= 0; currentSum--)
                {
                    if (currentCoin <= currentSum && memo[row - 1, currentSum - currentCoin] != 0)
                    {
                        memo[row, currentSum]++;
                    }
                    else
                    {
                        memo[row, currentSum] = memo[row - 1, currentSum];
                    }
                }
            }
        }
    }
}
