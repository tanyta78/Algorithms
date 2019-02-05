namespace PermAlgosCompare
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Program
    {
        public static void Main(string[] args)
        {
            //Test();
            Performance();
        }

        /// <summary>
        /// Heap's algorithm to find all permutations. Non recursive, more efficient.From StackOverflow user https://stackoverflow.com/users/452845/eric-ouellet
        /// </summary>
        /// <param name="items">Items to permute in each possible ways</param>
        /// <param name="funcExecuteAndTellIfShouldStop"></param>
        /// <returns>Return true if cancelled</returns> 
        public static bool ForAllPermutation<T>(T[] items, Func<T[], bool> funcExecuteAndTellIfShouldStop)
        {
            int countOfItem = items.Length;

            if (countOfItem <= 1)
            {
                return funcExecuteAndTellIfShouldStop(items);
            }

            var indexes = new int[countOfItem];
            for (int i = 0; i < countOfItem; i++)
            {
                indexes[i] = 0;
            }

            if (funcExecuteAndTellIfShouldStop(items))
            {
                return true;
            }

            for (int i = 1; i < countOfItem;)
            {
                if (indexes[i] < i)
                { // On the web there is an implementation with a multiplication which should be less efficient.
                    if ((i & 1) == 1) // if (i % 2 == 1)  ... more efficient ??? At least the same.
                    {
                        Swap(ref items[i], ref items[indexes[i]]);
                    }
                    else
                    {
                        Swap(ref items[i], ref items[0]);
                    }

                    if (funcExecuteAndTellIfShouldStop(items))
                    {
                        return true;
                    }

                    indexes[i]++;
                    i = 1;
                }
                else
                {
                    indexes[i++] = 0;
                }
            }

            return false;
        }

        /// <summary>
        /// This function is to show a linq way but is far less efficient
        /// From: StackOverflow user: Pengyang : http://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        /// <summary>
        /// Knuths's algorithm to find all permutations. Non recursive, more efficient.From StackOverflow user https://stackoverflow.com/users/26742/sani-singh-huttunen
        /// </summary>
        /// <param name="numList">Items to permute in each possible ways</param>
        /// <returns>Return true if cancelled</returns> 
        public static bool NextPermutation(int[] numList)
        {
            /*
             Knuths
             1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
             2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
             3. Swap a[j] with a[l].
             4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

             */
            var largestIndex = -1;
            for (var i = numList.Length - 2; i >= 0; i--)
            {
                if (numList[i] < numList[i + 1])
                {
                    largestIndex = i;
                    break;
                }
            }

            if (largestIndex < 0) return false;

            var largestIndex2 = -1;
            for (var i = numList.Length - 1; i >= 0; i--)
            {
                if (numList[largestIndex] < numList[i])
                {
                    largestIndex2 = i;
                    break;
                }
            }

            var tmp = numList[largestIndex];
            numList[largestIndex] = numList[largestIndex2];
            numList[largestIndex2] = tmp;

            for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
            {
                tmp = numList[i];
                numList[i] = numList[j];
                numList[j] = tmp;
            }

            return true;

        }

        /// <summary>
        /// Knuths's algorithm to find all permutations. Non recursive, more efficient.From StackOverflow user https://stackoverflow.com/users/1282539/simplevar
        /// </summary>
        /// <param name="numList">Items to permute in each possible ways</param>
        /// <returns>Return true if cancelled</returns> 
        public static bool NextPermutation<T>(T[] elements) where T : IComparable<T>
        {
            // More efficient to have a variable instead of accessing a property
            var count = elements.Length;

            // Indicates whether this is the last lexicographic permutation
            var done = true;

            // Go through the array from last to first
            for (var i = count - 1; i > 0; i--)
            {
                var curr = elements[i];

                // Check if the current element is less than the one before it
                if (curr.CompareTo(elements[i - 1]) < 0)
                {
                    continue;
                }

                // An element bigger than the one before it has been found,
                // so this isn't the last lexicographic permutation.
                done = false;

                // Save the previous (bigger) element in a variable for more efficiency.
                var prev = elements[i - 1];

                // Have a variable to hold the index of the element to swap
                // with the previous element (the to-swap element would be
                // the smallest element that comes after the previous element
                // and is bigger than the previous element), initializing it
                // as the current index of the current item (curr).
                var currIndex = i;

                // Go through the array from the element after the current one to last
                for (var j = i + 1; j < count; j++)
                {
                    // Save into variable for more efficiency
                    var tmp = elements[j];

                    // Check if tmp suits the "next swap" conditions:
                    // Smallest, but bigger than the "prev" element
                    if (tmp.CompareTo(curr) < 0 && tmp.CompareTo(prev) > 0)
                    {
                        curr = tmp;
                        currIndex = j;
                    }
                }

                // Swap the "prev" with the new "curr" (the swap-with element)
                elements[currIndex] = prev;
                elements[i - 1] = curr;

                // Reverse the order of the tail, in order to reset it's lexicographic order
                for (var j = count - 1; j > i; j--, i++)
                {
                    var tmp = elements[j];
                    elements[j] = elements[i];
                    elements[i] = tmp;
                }

                // Break since we have got the next permutation
                // The reason to have all the logic inside the loop is
                // to prevent the need of an extra variable indicating "i" when
                // the next needed swap is found (moving "i" outside the loop is a
                // bad practice, and isn't very readable, so I preferred not doing
                // that as well).
                break;
            }

            // Return whether this has been the last lexicographic permutation.
            return done;
        }

        /// <summary>
        /// Swap 2 elements of same type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Func to show how to call. It does a little test for an array of 3 items.
        /// </summary>
        public static void Test()
        {
            //ForAllPermutation("123".ToCharArray(), (vals) =>
            //{
            //    Console.WriteLine(String.Join("", vals));
            //    return false;
            //});

            int[] values = new int[] { 0, 1, 2 };

            Console.WriteLine("Ouellet heap's algorithm implementation");
            ForAllPermutation(values, (vals) =>
            {
                Console.WriteLine(String.Join("", vals));
                return false;
            });

            Console.WriteLine("Linq algorithm");
            foreach (var v in GetPermutations(values, values.Length))
            {
                Console.WriteLine(String.Join("", v));
            }

            values = new int[] { 0, 1, 2 };

            Console.WriteLine("SimpleVar lexicographic order Knuths algorithm");
            Console.WriteLine(string.Join("", values));

            while (!NextPermutation<int>(values))
            {
                Console.WriteLine(string.Join("", values));
            }

            values = new int[] { 0, 1, 2 };

            Console.WriteLine("Sami lexicographic order Knuths algorithm");
            Console.WriteLine(string.Join("", values));

            while (NextPermutation(values))
            {
                Console.WriteLine(string.Join("", values));
            }

        }


        /// <summary>
        /// Func to check performance for an array of 10 items.
        /// </summary>
        public static void Performance()
        {

            // Performance Heap's against Linq version : huge differences
            int count = 0;
            int[] values = new int[10];
            int[] numbers = new int[10];
            int[] numbers2 = new int[10];


            for (int n = 0; n < values.Length; n++)
            {
                values[n] = n;
                numbers[n] = n;
                numbers2[n] = n;
            }

            Stopwatch stopWatch = new Stopwatch();

            ForAllPermutation(values, (vals) =>
            {
                count++;
                return false;
            });

            stopWatch.Stop();
            Console.WriteLine($"Ouellet heap's algorithm implementation {count} items in {stopWatch.ElapsedMilliseconds} millisecs");

            count = 0;
            stopWatch.Reset();
            stopWatch.Start();

            foreach (var vals in GetPermutations(values, values.Length))
            {
                count++;
                
            }

            stopWatch.Stop();
            Console.WriteLine($"Linq {count} items in {stopWatch.ElapsedMilliseconds} millisecs");

            count = 1;
            stopWatch.Reset();
            stopWatch.Start();

            while (NextPermutation(numbers))
            {
                count++;
            }

            stopWatch.Stop();
            Console.WriteLine($"Knuhts Sami {count} items in {stopWatch.ElapsedMilliseconds} millisecs");

            count = 1;
            stopWatch.Reset();
            stopWatch.Start();

            while (!NextPermutation<int>(numbers2))
            {
                count++;
            }

            stopWatch.Stop();
            Console.WriteLine($"Knuhts SimpleVar {count} items in {stopWatch.ElapsedMilliseconds} millisecs");
        }
    }
}
