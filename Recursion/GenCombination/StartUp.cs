namespace GenCombination
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var set = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var k = int.Parse(Console.ReadLine());

            var vector = new int[k];
            GenCombs(set,vector,0,0);
        }

        private static void GenCombs(int[] set, int[] vector, int index, int border)
        {
            if (index > vector.Length - 1)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenCombs(set,vector,index+1,i+1);
                }
            }
        }
    }
}
