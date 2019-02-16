namespace MinimumEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int replaceCost;
        private static int insertCost;
        private static int deleteCost;
        private static int[,] dp;

       public static void Main(string[] args)
       {
           //only allowed to modify s1
           //The goal is to find the sequence of operations which will produce s2 from s1 with minimal cost.
           replaceCost = int.Parse(Console.ReadLine().Split(' ').ToArray()[2]);
           insertCost = int.Parse(Console.ReadLine().Split(' ').ToArray()[2]);
           deleteCost = int.Parse(Console.ReadLine().Split(' ').ToArray()[2]);

           var s1 = Console.ReadLine().Split(' ').ToArray()[2];
           var s2 = Console.ReadLine().Split(' ').ToArray()[2];

           dp = new int [s1.Length + 1, s2.Length + 1];

           for (int colIndex = 1; colIndex <= s2.Length; colIndex++)
           {
               dp[0, colIndex] = dp[0, colIndex - 1] + insertCost;
           }

           for (int row = 1; row <= s1.Length; row++)
           {
               dp[row, 0] = dp[row - 1, 0] + deleteCost;
           }

           for (int row = 1; row <= s1.Length; row++)
           {
               for (int col = 1; col <= s2.Length; col++)
               {
                   if (s1[row-1]==s2[col-1])
                   {
                       dp[row, col] = dp[row - 1, col - 1];
                   }
                   else
                   {
                       var delete = dp[row - 1, col] + deleteCost;
                       var insert = dp[row, col - 1] + insertCost;
                       var replace = dp[row - 1, col - 1]+replaceCost;

                       dp[row, col] = Math.Min(delete, Math.Min(insert, replace));
                   }
               }
           }

          

           PrintResult(s1,s2);
       }

       private static void PrintResult(string s1, string s2)
       {
           Console.WriteLine($"Minimum edit distance:{dp[s1.Length,s2.Length]}");

           var resultOperations = new Stack<string>();
           int fIndex = s1.Length;
           int sIndex = s2.Length;
           while (fIndex > 0 && sIndex > 0)
           {
               if (s1[fIndex - 1] == s2[sIndex - 1])
               {
                   fIndex--;
                   sIndex--;
               }
               else
               {
                   int replace = dp[fIndex - 1, sIndex - 1] + replaceCost;
                   int delete = dp[fIndex - 1, sIndex] + deleteCost;
                   int insert = dp[fIndex, sIndex - 1] + insertCost;
                   if (replace <= delete && replace <= insert)
                   {
                       resultOperations.Push($"REPLACE({fIndex - 1}, {s2[sIndex - 1]})");
                       fIndex--;
                       sIndex--;
                   }
                   else if (delete < replace && delete < insert)
                   {
                       resultOperations.Push($"DELETE({fIndex - 1})");
                       fIndex--;
                   }
                   else
                   {
                       resultOperations.Push($"INSERT({sIndex - 1}, {s2[sIndex - 1]})");
                       sIndex--;
                   }
               }
           }

           while (fIndex > 0)
           {
               resultOperations.Push($"DELETE({fIndex - 1})");
               fIndex--;
           }

           while (sIndex > 0)
           {
               resultOperations.Push($"INSERT({sIndex - 1}, {s2[sIndex - 1]})");
               sIndex--;
           }

           foreach (string resultOperation in resultOperations)
           {
               Console.WriteLine(resultOperation);
           }
       }
    }
}
