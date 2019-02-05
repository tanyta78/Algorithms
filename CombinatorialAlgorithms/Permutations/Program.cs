namespace Permutations
{
    using System;

    public class Program
    {
        static string[] elements = new string[] { "a", "b", "c" };
        static string[] vector = new string[3];
        private static bool[] used = new bool[elements.Length];

        public static void Main(string[] args)
        {
            //GeneratePermutations(0);
            GeneratePermutationsWithSwapAlgo(0);
        }

        private static void GeneratePermutationsWithSwapAlgo(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join("", elements));
            }
            else
            {
                GeneratePermutationsWithSwapAlgo(index+1);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    GeneratePermutationsWithSwapAlgo(index+1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int i, int j)
        {
            var temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }

        private static void GeneratePermutations(int index)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    vector[index] = elements[i];
                    GeneratePermutations(index + 1);
                    used[i] = false;
                }

            }
        }
    }
}
