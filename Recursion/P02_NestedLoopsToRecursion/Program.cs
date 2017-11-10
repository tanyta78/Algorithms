namespace P02_NestedLoopsToRecursion
{
    using System;

    public class Program
    {
       public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] arr = new int[number];
            int index = 0;
            GenerateValues(arr, index, number);

        }

        private static void GenerateValues(int[] arr, int index, int number)
        {
            throw new NotImplementedException();
        }
    }
}
