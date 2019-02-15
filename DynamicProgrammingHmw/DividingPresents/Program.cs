namespace DividingPresents
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private const int Not_Calculated = -1;
        private static int[] possibleSumsWithPresentIndexUsed;
        private static int[] presents;

        public static void Main(string[] args)
        {
            presents = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var total = presents.Sum();
            possibleSumsWithPresentIndexUsed = new int[total + 1];
            possibleSumsWithPresentIndexUsed[0] = 0;

            for (int i = 1; i < total + 1; i++)
            {
                possibleSumsWithPresentIndexUsed[i] = Not_Calculated;
            }

            for (int presentIndex = 0; presentIndex < presents.Length; presentIndex++)
            {
                var currentPresentValue = presents[presentIndex];

                for (int j = total; j >= 0; j--)
                {
                    if (possibleSumsWithPresentIndexUsed[j] != Not_Calculated &&
                        possibleSumsWithPresentIndexUsed[j + currentPresentValue] == Not_Calculated)
                    {
                        possibleSumsWithPresentIndexUsed[j + currentPresentValue] = presentIndex;
                    }
                }
            }

            var equality = total / 2;

            for (int i = equality; i >= 0; i--)
            {
                if (possibleSumsWithPresentIndexUsed[i] != Not_Calculated)
                {
                    int alanPresentsValue = i;
                    int bobPresentsValue = total - i;
                    Console.WriteLine($"Difference: {bobPresentsValue - alanPresentsValue}");
                    Console.WriteLine($"Alan:{alanPresentsValue} Bob:{bobPresentsValue}");
                    Console.WriteLine($"Alan takes: {GetAlanPresents(alanPresentsValue)}");
                    Console.WriteLine("Bob takes the rest.");
                    break;
                }
            }

        }

        private static string GetAlanPresents(int index)
        {
            var result = new StringBuilder();

            while (index != 0)
            {
                var presentValue = presents[possibleSumsWithPresentIndexUsed[index]];
                result.Append(presentValue);
                result.Append(" ");
                index = index - presentValue;

            }

            return result.ToString();
        }
    }
}
