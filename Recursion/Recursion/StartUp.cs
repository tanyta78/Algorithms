namespace Recursion
{
    using System;
    using System.Linq;

    public class StartUp
    {
      public static void Main()
      {
          int[] numbers = Console.ReadLine()
              .Split()
              .Select(int.Parse)
              .ToArray();
            
          Console.WriteLine(Sum(numbers,0));
      }

        private static int Sum(int[] numbers,int index)
        {
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }
            
            return numbers[index] + Sum(numbers, index + 1);
        }
    }
}
