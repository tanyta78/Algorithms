namespace LongestIncreasingSubsequence
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int[] sequence;
        private static int[] memo;
        private static int[] next;

        public static void Main(string[] args)
        {
            sequence = Console.ReadLine()
                              .Split(' ')
                              .Select(int.Parse).ToArray();

            memo = new int[sequence.Length];
            next = new int[sequence.Length];

            for (int i = 0; i < sequence.Length; i++)
            {
                LIS(i);
            }


            var maxLisCount = memo.Max();
            var index = Array.IndexOf(memo, maxLisCount);
            PrintLIS(index);
            Console.WriteLine();
        }

        private static void PrintLIS(int index)
        {
            while (next[index] != index)
            {
                Console.Write(sequence[index] + " ");
                index = next[index];
            }
            Console.Write(sequence[index]);

        }

        private static int LIS(int index)
        {
            if (memo[index] != 0)
            {
                return memo[index];
            }

            int maxLength = 1;
            next[index] = index;
            for (int i = index + 1; i < sequence.Length; i++)
            {
                if (sequence[index] < sequence[i])
                {
                    int length = LIS(i);
                    if (length >= maxLength)
                    {
                        maxLength = length + 1;
                        next[index] = i;
                    }
                }
            }

            memo[index] = maxLength;
            return maxLength;

        }
    }
}
