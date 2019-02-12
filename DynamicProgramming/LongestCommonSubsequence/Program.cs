namespace LongestCommonSubsequence
{
    using System;

    public class Program
    {
        static int[,] lcs;
        static string firstStr;
        static string secondStr;

       public static void Main(string[] args)
        {
            //Considering two sequences S1 and S2, the longest common subsequence is a sequence which is a subsequence of both S1 and S2. For instance, if we have two strings (sequences of characters), "abc" and "adb", the LCS is "ab" – it is a subsequence of both sequences and it is the longest (there are two other subsequences – "a" and "b").

            firstStr = Console.ReadLine();
            secondStr = Console.ReadLine();
            lcs = new int[firstStr.Length, secondStr.Length];

            Console.WriteLine();

        }

        private static object FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            throw new NotImplementedException();
        }
    }
}
