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

            //firstStr = "GCGCAATG";
           // secondStr = "GCCCTAGCG";

            lcs = new int[firstStr.Length + 1, secondStr.Length + 1];

           // FindLongestCommonSubseqIterative();
           FindLCSRecursive();
            
            // PrintLongestCommonSubseq();
        }

        private static void FindLongestCommonSubseqIterative()
        {
            for (int row = 1; row <= firstStr.Length; row++)
            {
                for (int col = 1; col <= secondStr.Length; col++)
                {
                    var up = lcs[row - 1, col];
                    var left = lcs[row, col - 1];

                    var result = Math.Max(up, left);

                    if (firstStr[row - 1] == secondStr[col - 1])
                    {
                        result = Math.Max(lcs[row - 1, col - 1] + 1, result);
                    }

                    lcs[row, col] = result;
                }
            }

            Console.WriteLine(lcs[firstStr.Length, secondStr.Length]);

        }

        private static void PrintLongestCommonSubseq()
        {
            var currentRow = firstStr.Length;
            var currentCol = secondStr.Length;

            while (currentCol > 0 && currentRow > 0)
            {
                if (firstStr[currentRow - 1] == secondStr[currentCol - 1])
                {
                    Console.WriteLine(firstStr[currentRow - 1]);
                    currentCol--;
                    currentRow--;
                }
                else if (lcs[currentRow - 1, currentCol] == lcs[currentRow, currentCol - 1])
                {
                    currentRow--;
                }
                else
                {
                    currentCol--;
                }
            }
        }

        private static void FindLCSRecursive()
        {
            InitializeMatrix();
           var lcsLength = CalcLCS(firstStr.Length - 1, secondStr.Length - 1);
            Console.WriteLine(lcsLength);
           // PrintLongestCommonSubseq();
        }


        private static int CalcLCS(int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return 0;
            }

            if (lcs[row, col] == -1)
            {
                var up = CalcLCS(row - 1, col);
                var left = CalcLCS(row, col - 1);
                var result = Math.Max(up, left);

                if (firstStr[row] == secondStr[col])
                {
                    result = Math.Max(CalcLCS(row - 1, col - 1) + 1, result);
                }

                lcs[row, col] = result;
            }

            return lcs[row, col];
        }

        private static void InitializeMatrix()
        {
            for (int row = 0; row < firstStr.Length; row++)
            {
                for (int col = 0; col < secondStr.Length; col++)
                {
                    lcs[row, col] = -1;
                }
            }
        }
    }
}
