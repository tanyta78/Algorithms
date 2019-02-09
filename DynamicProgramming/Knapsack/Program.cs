namespace Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Item[] items;
        private static int capacity;
        private static int[,] maxPriceMatrix;
        private static bool[,] isItemTakenMatrix;

        public static void Main(string[] args)
        {
            capacity = int.Parse(Console.ReadLine());

            ReadItems();
            
            FillKnapsack(items, capacity);

            var result = GetSolution();

            Console.WriteLine($"Total Weight: {result.Sum(i => i.Weight)}");
            Console.WriteLine($"Total Value: {result.Sum(i => i.Price)}");
            Console.WriteLine(String.Join(Environment.NewLine, result.Select(i => i.Name)));
        }

        private static List<Item> GetSolution()
        {
            var itemsTaken = new List<Item>();
            int itemIndex = items.Length - 1;

            while (itemIndex>=0)
            {
                if (isItemTakenMatrix[itemIndex+1,capacity])
                {
                    var item = items[itemIndex];
                    itemsTaken.Add(item);
                    capacity -= item.Weight;
                }
                
                itemIndex--;
            }

            itemsTaken.Reverse();

            return itemsTaken;
        }

        private static void FillKnapsack(Item[] items, int capacity)
        {
            maxPriceMatrix = new int[items.Length + 1, capacity + 1];
            isItemTakenMatrix = new bool[items.Length + 1, capacity + 1];

            for (int i = 0; i < items.Length; i++)
            {
                for (int currentCapacity = 1; currentCapacity <= capacity; currentCapacity++)
                {
                    if (items[i].Weight > currentCapacity)
                        continue;

                    int valueIncluded = items[i].Price + maxPriceMatrix[i, currentCapacity - items[i].Weight];
                    int valueExcluded = maxPriceMatrix[i, currentCapacity];

                    if (valueIncluded > valueExcluded)
                    {
                        maxPriceMatrix[i + 1, currentCapacity] = valueIncluded;
                        isItemTakenMatrix[i + 1, currentCapacity] = true;
                    }
                    else
                    {
                        maxPriceMatrix[i + 1, currentCapacity] = valueExcluded;
                    }

                }
            }

        }

        private static void ReadItems()
        {
            var input = Console.ReadLine();
            var itemsList = new List<Item>();
            while (input != "end")
            {
                var tokens = input
                             .Split(' ')
                             .ToArray();
                var item = new Item(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]));

                itemsList.Add(item);

                input = Console.ReadLine();
            }

            items = itemsList.OrderBy(i => i.Name).ToArray();
        }

        public class Item
        {
            public Item(string name, int weight, int price)
            {
                this.Weight = weight;
                this.Price = price;
                this.Name = name;
            }

            public int Weight { get; set; }
            public int Price { get; set; }
            public string Name { get; set; }
        }
    }
}
