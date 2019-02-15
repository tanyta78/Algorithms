namespace BinominalCoefficients
{
    using System;

    public class Program
    {
        private static long[,] binoms;

        public static void Main(string[] args)
        {
            //A second useful application of Pascal's triangle is in the calculation of combinations. For example, the number of combinations of n things taken k at a time (called n choose k
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            binoms = new long[n + 1, k + 1];
            Console.WriteLine(Binom(n, k));

        }

        private static long Binom(int n, int k)
        {
            if (binoms[n, k] != 0)
            {
                return binoms[n, k];
            }

            if (k > n)
            {
                binoms[n, k] = 0;
                return 0;
            }
            
            if (k == 0 || k == n)
            {
                binoms[n, k] = 1;
                return 1;
            }

            binoms[n, k] = Binom(n - 1, k - 1) + Binom(n - 1, k);

            return binoms[n, k];
        }
    }
}
