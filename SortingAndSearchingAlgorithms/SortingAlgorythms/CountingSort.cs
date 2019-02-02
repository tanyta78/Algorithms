namespace SortingAlgorythms
{
    using System;

    public static class CountingSort
    {
        public static void Sort(int[] arr)
        {
            //find smallest and largest value
            var minVal = arr[0];
            var maxVal = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < minVal)
                {
                    minVal = arr[i];
                }

                if (arr[i] > maxVal)
                {
                    maxVal = arr[i];
                }
            }

            //generate array with counts
            var counts = new int[maxVal - minVal + 1];

            //for each element in arr increase the respective counter by 1
            for (int idx = 0; idx < arr.Length; idx++)
            {
                int element = arr[idx];
                var index = element - minVal;
                counts[index]++;
            }

            //for each counter, starting from smallest key while counter is non-zero, restore element to arr and decrease counter by 1
            int key = 0;
            for (int i = minVal; i <= maxVal; i++)
            {
                var maxIndex = counts[i - minVal];
                for (int j = 0; j < maxIndex; j++)
                {
                    arr[key++] = i;
                   
                }
            }
        }
    }
}
