namespace CombinationWithRepetition
{
    using System;
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

            GenCombinationsWithRep(0,0);
        }

        private static void GenCombinationsWithRep(int index, int border)
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
                    GenCombinationsWithRep(index+1,i);
                }
            }
        }
    }
}
