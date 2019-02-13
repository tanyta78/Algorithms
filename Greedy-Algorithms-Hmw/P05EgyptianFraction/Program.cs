namespace P05EgyptianFraction
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var fraction = Console.ReadLine().Split('/').Select(int.Parse).ToArray();
            var fractionNumerator = fraction[0];
            var fractionDenominator = fraction[1];

            if (fractionDenominator <= fractionNumerator)
            {
                Console.WriteLine($"Error (fraction is equal to or greater than 1)");
            }

            Console.WriteLine($"{fractionNumerator}/{fractionDenominator} = ");

            while (true)
            {
               
            }
        }
    }
}
