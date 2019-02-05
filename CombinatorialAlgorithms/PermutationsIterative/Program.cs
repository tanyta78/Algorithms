namespace PermutationsIterative
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static char[] arr;
        private static int[] swaps;

        private static bool leftToRight = true;
        private static bool rightToLeft = false;

        public static void Main(string[] args)
        {
            arr = Console.ReadLine()
                         .Split()
                         .Select(Char.Parse)
                         .ToArray();
            swaps = Enumerable.Range(0, arr.Length).ToArray();

            var perm = Gen();

            while (perm != null)
            {
                Console.WriteLine(string.Join(" ", perm));
                perm = Gen();
            }
            //PermutateStringTest();
        }

        private static char[] Gen()
        {
            if (arr == null)
            {
                return null;
            }

            var helper = new char[arr.Length];
            Array.Copy(arr, helper, arr.Length);

            int i = swaps.Length - 1;

            while (i >= 0 && swaps[i] == arr.Length - 1)
            {
                Swap(i, swaps[i]);
                swaps[i] = i;
                i--;
            }

            if (i < 0)
            {
                arr = null;
            }
            else
            {
                int prev = swaps[i];
                Swap(i, prev);
                int next = prev + 1;
                swaps[i] = next;
                Swap(i, next);
            }

            return helper;
        }

        private static void Swap(int i, int v)
        {
            var temp = arr[i];
            arr[i] = arr[v];
            arr[v] = temp;
        }

        static void PermutateStringTest()
        {
            foreach (var list in Permutate(arr.ToList(), arr.Length))
            {
                var perm = (List<char>)list;
                Console.WriteLine(String.Join(" ", perm));
            }
        }

        public static void RotateRight(IList sequence, int count)
        {
            object tmp = sequence[count - 1];
            sequence.RemoveAt(count - 1);
            sequence.Insert(0, tmp);
        }

        public static IEnumerable<IList> Permutate(IList sequence, int count)
        {
            if (count == 1) yield return sequence;
            else
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var perm in Permutate(sequence, count - 1))
                        yield return perm;
                    RotateRight(sequence, count);
                }
            }
        }
    }
}
