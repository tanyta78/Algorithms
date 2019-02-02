namespace SearchingAlgorithms
{
    public class InterpolationSearch
    {
        public static int IndexOf(int[] sortedArr, int key)
        {
            int low = 0;
            int high = sortedArr.Length - 1;

            while (sortedArr[low] <= key && sortedArr[high] >= key)
            {
                int mid = low + ((key - sortedArr[low]) * (high - low)) / (sortedArr[high] - sortedArr[low]);

                if (sortedArr[mid] < key)
                {
                    low = mid + 1;
                }
                else if (sortedArr[mid] > key)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }


            }

            if (sortedArr[low] == key)
            {
                return low;
            }
            else
            {
                return -1;
            }

        }
    }
}
