namespace SubsetSum
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static int targetSum;
        private static int[] nums;
        private static HashSet<int> possibleSums;
        private static Dictionary<int, int> possibleSumsDictionary;

        public static void Main(string[] args)
        {
            targetSum = 6;
            nums = new int[] { 3, 5, 1, 4, 2 };

            GetPossibleSumDictionary();

            if (possibleSumsDictionary.ContainsKey(targetSum))
            {
                var result = FindSubset();

                Console.WriteLine($"{targetSum} = {string.Join(" + ", result)}");
            }
            else
            {
                Console.WriteLine("No possible way to get target sum with this set of numbers.");
            }

        }

        private static List<int> FindSubset()
        {
            var subset = new List<int>();
            var sum = targetSum;

            while (sum > 0)
            {
                var lastNum = possibleSumsDictionary[sum];
                subset.Add(lastNum);
                sum -= lastNum;
            }

            subset.Reverse();
            return subset;
        }

        private static List<List<int>> FindSubsetS()
        {
            var subset = new List<List<int>>();
           
            return subset;
        }

        private static void GetPossibleSum()
        {
            possibleSums = new HashSet<int>() { 0 };

            for (int i = 0; i < nums.Length; i++)
            {
                var newSums = new HashSet<int>();
                foreach (var sum in possibleSums)
                {
                    var currentSum = sum + nums[i];
                    newSums.Add(currentSum);
                }

                possibleSums.UnionWith(newSums);
            }
        }

        private static void GetPossibleSumDictionary()
        {
            possibleSumsDictionary = new Dictionary<int, int>();
            possibleSumsDictionary.Add(0, 0);

            for (int i = 0; i < nums.Length; i++)
            {
                var newSums = new Dictionary<int, int>();
                foreach (var sum in possibleSumsDictionary.Keys)
                {
                    var currentSum = sum + nums[i];
                    if (!possibleSumsDictionary.ContainsKey(currentSum))
                    {
                        newSums.Add(currentSum, nums[i]);
                    }
                }

                foreach (var sum in newSums)
                {
                    possibleSumsDictionary.Add(sum.Key, sum.Value);
                }

            }
        }
    }
}
