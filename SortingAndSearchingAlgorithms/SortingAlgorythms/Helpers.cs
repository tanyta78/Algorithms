namespace SortingAlgorythms
{
    using System;

    public static class Helpers
    {
        public static void Swap<T>(T[] arr, int firstIndex, int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }

        public static bool IsLess(IComparable first, IComparable second)
        {
            return first.CompareTo(second) < 0;
        }

      
        public static bool IsSorted<T>(T[] arr) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].CompareTo(arr[i]) > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
