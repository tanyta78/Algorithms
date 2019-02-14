namespace P05EgyptianFraction
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var fraction = Console.ReadLine().Split('/').Select(long.Parse).ToArray();
            var fractionNumerator = fraction[0];//43
            var fractionDenominator = fraction[1];//48

            if (fractionDenominator <= fractionNumerator)
            {
                Console.WriteLine($"Error (fraction is equal to or greater than 1)");

            }
            else
            {
                Console.Write($"{fractionNumerator}/{fractionDenominator} = ");
                var currentDenominator = 2;
                var result = new StringBuilder();
                // 43/48 to 1/2
                while (fractionNumerator > 0)
                {
                    var equatedFractionNumerator = fractionNumerator * currentDenominator;
                    var equatedPartNumerator = fractionDenominator;

                    if (equatedPartNumerator > equatedFractionNumerator)
                    {
                        currentDenominator++;
                        continue;
                    }

                    fractionNumerator = equatedFractionNumerator - equatedPartNumerator;
                    fractionDenominator *= currentDenominator;
                    result.Append($"1/{currentDenominator} + ");
                    currentDenominator++;
                }

                result.Remove(result.Length - 3, 2);
                Console.WriteLine(result);
            }
        }
    }
}
