namespace SortingAlgorythms
{
    using System;

    public static class Insertion
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var prev = i - 1;
                var curr = i;
                while (true)
                {
                    if (prev < 0 || Helpers.IsLess(arr[prev], arr[curr]))
                    {
                        break;
                    }

                    Helpers.Swap(arr, prev, curr);
                    prev--;
                    curr--;
                }
            }
        }
    }
}
