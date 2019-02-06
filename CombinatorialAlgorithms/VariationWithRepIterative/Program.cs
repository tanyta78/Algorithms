namespace VariationWithRepIterative
{
    using System;
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

            while (true)
            {
                Print();
                var index = slots - 1;

                while (index >= 0 && variation[index] == elementsCount - 1)
                {
                    index--;
                }

                if (index < 0)
                {
                    break;
                }

                variation[index]++;

                for (int i = index + 1; i < slots; i++)
                {
                    variation[i] = 0;
                }
            }

        }

        private static void Print()
        {
            for (int i = 0; i < variation.Length; i++)
            {
                Console.Write(elements[variation[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}
