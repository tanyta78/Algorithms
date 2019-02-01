namespace SortingAlgorythms
{
    using System;

    public static class Shuffle
    {
        public static void FisherYatesAlgo<T>(T[] arr)
        {
            Random rnd = new Random();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int randomIndex = rnd.Next(i + 1, arr.Length);
                Helpers.Swap(arr, i, randomIndex);
            }
        }
    }
}
