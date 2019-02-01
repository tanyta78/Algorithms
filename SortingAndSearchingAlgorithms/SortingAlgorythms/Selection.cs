namespace SortingAlgorythms
{
    using System;

    public static class Selection
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            for (int index = 0; index < arr.Length; index++)
            {
                int min = index;

                for (int curr = index + 1; curr < arr.Length; curr++)
                {
                    if (Helpers.IsLess(arr[curr], arr[min]))
                    {
                        min = curr;
                    }
                }

                Helpers.Swap(arr, min, index);
            }
        }
    }
}
