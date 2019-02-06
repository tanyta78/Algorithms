namespace VariationsWithRep
{
    using System;
    using System.Linq;

    public class Program
    {
        private static char[] elements;
        private static char[] variation;
        private static int slots;
        private static int elementsCount;

        public static void Main(string[] args)
        {

            elements = Console.ReadLine()
                              .Split(' ')
                              .Select(Char.Parse)
                              .ToArray();
            elementsCount = elements.Length;
            slots = int.Parse(Console.ReadLine());
            variation = new char[slots];

            Permutate(0);
        }

        private static void Permutate(int index)
        {
            if (index >= slots)
            {
                Console.WriteLine(String.Join(" ", variation));
            }
            else
            {
                for (int i = 0; i < elementsCount; i++)
                {
                    variation[index] = elements[i];
                    Permutate(index + 1);
                }
            }
        }
    }
}
