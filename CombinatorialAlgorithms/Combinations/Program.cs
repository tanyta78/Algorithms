using System;

namespace Combinations
{
    using System.Linq;

    public class Program
    {
        private static int slots ;
        private static int elementsCount;
        private static string[] elements ;
        private static string[] combination;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                              .Split(' ')
                             .ToArray();
            elementsCount = elements.Length;
            slots = int.Parse(Console.ReadLine());
            combination = new string[slots];

            GenCombinations(0, 0);
        }

        private static void GenCombinations(int index, int border)
        {
            if (index >= slots)
            {
                Console.WriteLine(string.Join(" ", combination));
            }
            else
            {
                for (int i = border; i < elementsCount; i++)
                {
                    combination[index] = elements[i];
                    GenCombinations(index+1,i+1);
                }
            }
        }
    }
}
