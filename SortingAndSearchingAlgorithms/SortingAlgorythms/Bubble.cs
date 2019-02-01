namespace SortingAlgorythms
{
    using System;

    public class Bubble
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (Helpers.IsLess(arr[j + 1], arr[j]))
                    {
                        Helpers.Swap(arr, j, j + 1);
                    }
                }
            }
        }
    }
}
