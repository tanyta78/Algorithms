namespace SortingAlgorythms
{
    using System;

    public class MergeSort<T> where T : IComparable
    {
        private static T[] aux;

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int start, int end)
        {
            //split each element into partitions of size 1
            if (start >= end)
            {
                return;
            }

            int middle = start + (end - start) / 2;
            Sort(arr, start, middle);
            Sort(arr, middle + 1, end);

            //recursively merge partitions
            Merge(arr, start, middle, end);
        }

        private static void Merge(T[] arr, int start, int middle, int end)
        {
            if (Helpers.IsLess(arr[middle], arr[middle + 1]))
            {
                return;
            }

            for (int i = start; i < end + 1; i++)
            {
                aux[i] = arr[i];
            }

            var leftPartStartIndex = start;
            var rightPartStartIndex = middle + 1;

            for (int k = start; k <= end; k++)
            {
                if(leftPartStartIndex> middle)
                {
                    arr[k] = aux[rightPartStartIndex++];
                }
                else if(rightPartStartIndex > end)
                {
                    arr[k] = aux[leftPartStartIndex++];
                }
                else if(Helpers.IsLess(aux[leftPartStartIndex], aux[rightPartStartIndex]))
                {
                    arr[k] = aux[leftPartStartIndex++];
                }
                else
                {
                    arr[k] = aux[rightPartStartIndex++];
                }
            }
        }
    }
}
