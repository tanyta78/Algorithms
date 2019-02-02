namespace SortingAlgorythms
{
    using System;

    public static class QuickSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            Shuffle.FisherYatesAlgo(arr);
            Sort<T>(arr, 0, arr.Length - 1);
        }

        private static void Sort<T>(T[] arr, int left, int right) where T : IComparable
        {
            if (right <= left)
            {
                return;
            }

            //optimization for less than 10 elements in arr
            if (right - left < 10)
            {
                Insertion.Sort(arr);
                return;
            }

            var partitionElementIndex = Partition(arr, left, right);
            Sort(arr, left, partitionElementIndex - 1);
            Sort(arr, partitionElementIndex + 1, right);
        }

        private static int Partition<T>(T[] arr, int left, int right) where T : IComparable
        {
            var leftScanIdx = left;
            var rightScanIdx = right + 1;
            var partitionElement = arr[left];

            while (true)
            {
                while (Helpers.IsLess(arr[++leftScanIdx], partitionElement))
                {
                    if (leftScanIdx == right)
                    {
                        break;
                    }
                }

                while (Helpers.IsLess(partitionElement, arr[--rightScanIdx]))
                {
                    if (rightScanIdx == left)
                    {
                        break;
                    }
                }

                if (leftScanIdx >= rightScanIdx)
                {
                    break;
                }

                Helpers.Swap(arr, leftScanIdx, rightScanIdx);


            }

            Helpers.Swap(arr, left, rightScanIdx);

            return rightScanIdx;
        }
    }
}
