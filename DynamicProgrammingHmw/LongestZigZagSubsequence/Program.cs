namespace LongestZigZagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            //1) Every even element is smaller than its neighbors and every odd element is larger than its neighbors, or
            //2) Every odd element is smaller than its neighbors and every even element is larger than its neighbors


            var numbers = Console.ReadLine()
                                 .Split(' ')
                                 .Select(int.Parse)
                                 .ToArray();
            
            var dp = new int[numbers.Length, 2];
            var prev = new int[numbers.Length, 2];

            dp[0, 0] = dp[0, 1] = 1;
            prev[0, 0] = prev[0, 1] = -1;

            var maxResult = 0;
            var maxIndexRow = 0;
            var maxIndexCol = 0;

            for (int currentIndex = 1; currentIndex < numbers.Length; currentIndex++)
            {
                for (int prevIndex = 0; prevIndex < currentIndex; prevIndex++)
                {
                    var currentNum = numbers[currentIndex];
                    var prevNum = numbers[prevIndex];

                    if (currentNum > prevNum && dp[currentIndex, 0] < dp[prevIndex, 1] + 1)
                    {
                        dp[currentIndex, 0] = dp[prevIndex, 1] + 1;
                        prev[currentIndex, 0] = prevIndex;

                    }

                    if (currentNum < prevNum && dp[currentIndex, 1] < dp[prevIndex, 0] + 1)
                    {
                        dp[currentIndex, 1] = dp[prevIndex, 0] + 1;
                        prev[currentIndex, 1] = prevIndex;
                    }

                }

                if (dp[currentIndex, 0] > maxResult)
                {
                    maxResult = dp[currentIndex, 0];
                    maxIndexCol = 0;
                    maxIndexRow = currentIndex;
                }

                if (dp[currentIndex, 1] > maxResult)
                {
                    maxResult = dp[currentIndex, 1];
                    maxIndexCol = 1;
                    maxIndexRow = currentIndex;
                }
            }

            var result = new List<int>();

            while (maxIndexRow >= 0)
            {
                result.Add(numbers[maxIndexRow]);
                maxIndexRow = prev[maxIndexRow, maxIndexCol];

                maxIndexCol = maxIndexCol == 1 ? 0 : 1;
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
