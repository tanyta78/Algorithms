using System;
using System.Linq;

namespace P01_ReverseArray
{
public class Program
    {
       public static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            ReversedArr(arr, 0,arr.Length-1);
            Console.WriteLine(string.Join(" ",arr));
        }

        private static void ReversedArr(int[] arr, int startIndex,int endIndex)
        {
            if (startIndex<endIndex)
            {
                int front = arr[startIndex];
                int end = arr[endIndex];

                arr[startIndex] = end;
                arr[endIndex] = front;

                ReversedArr(arr, startIndex + 1, endIndex - 1);
            }
            

        }
    }
}
