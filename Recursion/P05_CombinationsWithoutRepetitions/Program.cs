namespace P05_CombinationsWithoutRepetitions
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int[] combinaton;
        private static int[] setOfNumbers;

        public static void Main(string[] args)
        {
            var setCount = int.Parse(Console.ReadLine());
            var combsCount = int.Parse(Console.ReadLine());

            setOfNumbers = Enumerable.Range(1, setCount).ToArray();
            combinaton = new int[combsCount];

            GetCombs(0, 0);
        }

        private static void GetCombs(int setIndex, int combsIndex)
        {
            if (combsIndex == combinaton.Length)
            {
                PrintCombination();
            }
            else
            {
                for (int i = setIndex; i < setOfNumbers.Length; i++)
                {
                    combinaton[combsIndex] = setOfNumbers[i];
                    GetCombs(i + 1, combsIndex + 1);
                }
            }
        }

        private static void PrintCombination()
        {
            Console.WriteLine(String.Join(" ", combinaton));
        }
    }
}
