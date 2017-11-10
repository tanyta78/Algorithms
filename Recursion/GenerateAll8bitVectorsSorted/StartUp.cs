namespace GenerateAll8bitVectorsSorted
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];

            Generate(0,vector);
        }

        private static void Generate(int index, int[] vector)
        {
            if (index > vector.Length - 1)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                vector[index] = 0;
                Generate(index+1,vector);

                vector[index] = 1;
                Generate(index+1,vector);
            }
        }
    }
}
