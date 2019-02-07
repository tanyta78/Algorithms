namespace PascalTriangle
{
    using System;

    class Program
    {
        //Pascal's triangle is a triangular array of the binomial coefficients. From n choose k
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(Binom(n,k));
            
        }

        private static long Binom(int n, int k)
        {
            if (k > n)
            {
               return 0;
            }

            if (k==0 || k==n)
            {
                return 1;
            }

            return Binom(n - 1, k - 1) + Binom(n - 1, k);
        }
    }
}
