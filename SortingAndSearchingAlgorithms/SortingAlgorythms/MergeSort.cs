namespace SortingAlgorythms
{
    using System;

    public class MergeSort<T> where T : IComparable
    {
        private static T[] helper;

        public static void Sort(T[] arr)
        {
            helper = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int startIndex, int endIndex)
        {
            //split each element into partitions of size 1
            if (startIndex >= endIndex)
            {
                return;
            }

            int middleIndex = startIndex + (endIndex - startIndex) / 2;
            Sort(arr, startIndex, middleIndex);
            Sort(arr, middleIndex + 1, endIndex);

            //recursively merge partitions
            Merge(arr, startIndex, middleIndex, endIndex);
        }

        private static void Merge(T[] arr, int startIndex, int middleIndex, int endIndex)
        {
            if (
                middleIndex < 0
            || middleIndex + 1 >= arr.Length
            || Helpers.IsLess(arr[middleIndex], arr[middleIndex + 1]))
            {
                return;
            }

            for (int i = startIndex; i < endIndex + 1; i++)
            {
                helper[i] = arr[i];
            }

            var leftPartStartIndex = startIndex;
            var rightPartStartIndex = middleIndex + 1;

            for (int k = startIndex; k <= endIndex; k++)
            {
                if (leftPartStartIndex > middleIndex)
                {
                    arr[k] = helper[rightPartStartIndex++];
                }
                else if (rightPartStartIndex > endIndex)
                {
                    arr[k] = helper[leftPartStartIndex++];
                }
                else if (Helpers.IsLess(helper[leftPartStartIndex], helper[rightPartStartIndex]))
                {
                    arr[k] = helper[leftPartStartIndex++];
                }
                else
                {
                    arr[k] = helper[rightPartStartIndex++];
                }
            }
        }
    }
}
