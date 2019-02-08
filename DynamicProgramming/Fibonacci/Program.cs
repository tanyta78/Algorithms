namespace Fibonacci
{
    using System;

    public class Program
    {
        private static long[] memo;

        public static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            memo = new long[num + 1];
            Console.WriteLine(FindFibonacciMember(num));
        }

        private static long FindFibonacciMember(int number)
        {
            if (memo[number] != 0)
            {
                return memo[number];
            }

            if (number <= 2)
            {
                memo[1] = 1;
                memo[2] = 1;
                return 1;
            }

            memo[number] = FindFibonacciMember(number - 1) + FindFibonacciMember(number - 2);

            return memo[number];
        }
    }
}
