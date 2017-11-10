namespace Recursion_Factoriel
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Factoriel(number));
            ;
        }

        private static long Factoriel(int number)
        {
            if (number<2)
            {
                return 1;
            }

            return number * Factoriel(number - 1);
        }
    }
}
