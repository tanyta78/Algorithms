namespace SubsetSumsWithRepeat
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static int targetSum;
        private static int[] nums;
        private static bool[] possibleSums;


        public static void Main(string[] args)
        {
            targetSum = 6;
            nums = new int[] { 3, 5, 2 };

            GetPossibleSumWithRepeat();

            if (possibleSums[targetSum])
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
                for (int i = 0; i < nums.Length; i++)
                {
                    var newSum = sum - nums[i];
                    if (newSum >= 0 && possibleSums[newSum])
                    {
                        sum = newSum;
                        subset.Add(nums[i]);
                    }
                }
            }
            
            return subset;
        }

        private static void GetPossibleSumWithRepeat()
        {
            possibleSums = new bool[targetSum + 1];
            possibleSums[0] = true;

            for (int sum = 0; sum < possibleSums.Length; sum++)
            {
                if (possibleSums[sum])
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        var newSum = sum + nums[i];
                        if (newSum <= targetSum)
                        {
                            possibleSums[newSum] = true;
                        }
                    }
                }
            }
        }
    }
}
