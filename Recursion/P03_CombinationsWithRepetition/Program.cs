namespace P03_CombinationsWithRepetition
{
    using System;

    public class Program
    {
        private static int[] arr;

        public static void Main(string[] args)
        {
            var setCount = int.Parse(Console.ReadLine());
            var loopsCount = int.Parse(Console.ReadLine());
            arr = new int[loopsCount];
            Combinations(setCount);
        }

        private static void Combinations(int setCount, int index = 0, int element = 1)
        {
            var length = arr.Length;
            if (index >= length)
            {
                Console.WriteLine(String.Join(" ", arr));
                return;
            }

            for (int i = element; i <= setCount; i++)
            {
                arr[index] = i;
                Combinations(setCount, index + 1, i);
            }
        }
    }
}
