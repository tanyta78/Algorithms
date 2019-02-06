namespace VariationIterative
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static char[] elements;
        private static int[] variation;
         private static int slots;
        private static int elementsCount;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                              .Split(' ')
                              .Select(Char.Parse)
                              .ToArray();
            elementsCount = elements.Length;
            slots = int.Parse(Console.ReadLine());
            variation = new int[slots];

           
            foreach (var combination in FindCombinations(elementsCount, slots))
            {
                Print(combination);
            }

        }

        private static void Print(int[] combination)
        {
            for (int i = 0; i < slots; i++)
            {
                Console.Write(elements[combination[i]] + " ");
            }

            Console.WriteLine();
        }

        private static IEnumerable<int[]> FindCombinations(int n, int k)
        {
            var combination = Enumerable.Repeat(1, k).ToArray();
            while (true)
            {
                // generate current combination
                yield return (int[])combination.Clone();

                // find index which isn't going to overflow
                int index = k - 1;
                while (combination[index] == n)
                {
                    if (--index < 0) yield break;
                }

                // increment and fill right
                for (int finalDigit = combination[index] + 1; index < n; index++)
                {
                    combination[index] = finalDigit;
                }
            }
        }
    }
}
