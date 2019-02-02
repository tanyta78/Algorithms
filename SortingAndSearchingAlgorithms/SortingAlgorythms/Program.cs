namespace SortingAlgorythms
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new int[] { 15, 3, 12, 5, -6, 78, 2, 155, 45, -2, 5, -345 };

            var ordered = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            //SelectionSort
            // Selection.Sort(numbers);

            //BubbleSort
            // Bubble.Sort(numbers);

            //InsertionSort
            // Insertion.Sort(numbers);


            //Merge sort
           // MergeSort<int>.Sort(numbers);

           //Quick Sort
          // QuickSort.Sort(numbers);

           //CountingSort
           CountingSort.Sort(numbers);

             Console.WriteLine(string.Join(", ", numbers));
             Console.WriteLine(Helpers.IsSorted(numbers));

            //Shuffle.FisherYatesAlgo(ordered);
            //Console.WriteLine(string.Join(", ", ordered));
        }
    }
}
