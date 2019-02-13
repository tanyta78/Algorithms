namespace Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int count = 0;
        private static char[] word;

        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            word = input.ToCharArray();

            bool allUnique = IsUnique(input);

            if (allUnique)
            {
                CalculateFactorial(input);
            }
            else
            {
                Permutate(0);
            }

            Console.WriteLine(count);
        }

        private static bool IsUnique(string input)
        {
            return input.Distinct().Count() == input.Length;
        }

        private static void CalculateFactorial(string input)
        {
            count = 1;
            for (int i = 1; i <= input.Length; i++)
            {
                count *= i;
            }
        }

        private static void Permutate(int start)
        {
            if (start >= word.Length)
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if (word[i] == word[i - 1])
                    {
                        return;
                    }
                }
                count++;
            }
            else
            {
                var swapped = new HashSet<int>();
                for (int i = start; i < word.Length; i++)
                {
                    if (!swapped.Contains(word[i]))
                    {
                        Swap(start, i);
                        Permutate(start + 1);
                        Swap(start, i);
                        swapped.Add(word[i]);
                    }
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = word[first];
            word[first] = word[second];
            word[second] = temp;
        }

    }
}


