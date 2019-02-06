namespace PermutationsWithRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static string[] elements = new string[] { "A", "B", "B" };
        private static int[] arr = new int[] { 1, 3, 3 };

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ').ToArray();
            Gen(0);
           // PermutateRep(0, arr.Length - 1);
        }

        private static void Gen(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                Gen(index + 1);
                var used = new HashSet<string>();
                used.Add(elements[index]);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    if (!used.Contains(elements[i]))
                    {
                        used.Add(elements[i]);
                        Swap(elements, index, i);
                        Gen(index + 1);
                        Swap(elements, index, i);
                    }
                }
            }
        }

        private static void Swap<T>(T[] collection, int i, int j)
        {
            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }

        private static void PermutateRep(int start, int end)
        {
            Console.WriteLine(string.Join("", arr));

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(arr, left, right);
                        PermutateRep(left + 1, end);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[end] = firstElement;

            }
        }
    }
}
