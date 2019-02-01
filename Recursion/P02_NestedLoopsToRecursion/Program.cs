namespace P02_NestedLoopsToRecursion
{
    using System;
   
    public class Program
    {
        private static int[] loops;

        public static void Main(string[] args)
        {
            int loopsCount = int.Parse(Console.ReadLine());
            loops = new int[loopsCount];
            NestedLoops(loopsCount, 0);

        }

        private static void NestedLoops(int loopsCount, int currentLoop)
        {
            if (currentLoop==loopsCount)
            {
                Print(loops);
                return;
            }

            for (int counter = 1; counter <= loopsCount; counter++)
            {
                loops[currentLoop] = counter;
                NestedLoops(loopsCount,currentLoop+1);
            }
        }

        private static void Print(int[] loops)
        {
            Console.WriteLine(String.Join(" ", loops));
        }
    }
}
