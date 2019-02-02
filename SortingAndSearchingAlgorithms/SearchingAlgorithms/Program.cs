namespace SearchingAlgorithms
{
    using System;

    public class Program
    {
       public static void Main(string[] args)
       {
           int[] sortedArray = new[] {-12, -2, -1, 1, 2, 3, 4, 5, 7, 9, 12, 23, 34, 56, 78, 86, 87, 88, 90, 102};

          // var indexOfSearchedElement = BinarySearch.IndexOf(sortedArray, 5);
           var indexOfSearchedElement = InterpolationSearch.IndexOf(sortedArray, 5);

           Console.WriteLine(indexOfSearchedElement);
       }
    }
}
