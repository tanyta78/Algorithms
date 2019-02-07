using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var sortedCoins = coins.OrderByDescending(coin => coin).ToArray();
        var result = new Dictionary<int, int>();

        var currentSum = 0;
        var coinIndex = 0;

        while (currentSum < targetSum && coinIndex < sortedCoins.Length)
        {
            var currentCoin = sortedCoins[coinIndex];
            var currentCoinQuantity = (targetSum - currentSum) / currentCoin;

            if (currentCoinQuantity > 0)
            {
                result.Add(currentCoin, currentCoinQuantity);
                currentSum += currentCoinQuantity * currentCoin;
            }

            coinIndex++;
        }


        if (currentSum != targetSum)
        {
            throw new InvalidOperationException();
        }

        return result;
    }
}
