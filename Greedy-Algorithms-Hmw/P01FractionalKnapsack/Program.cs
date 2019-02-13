namespace P01FractionalKnapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Item> items;

        public static void Main(string[] args)
        {
            //Unlike the classical version of the problem where an object should either be taken in its entirety or not at all, in this version we can take a fraction of each item. 

            var capacity = double.Parse(Console.ReadLine().Split(' ').ToArray()[1]);
            var itemsCount = int.Parse(Console.ReadLine().Split(' ').ToArray()[1]);
            items = new List<Item>();

            for (int i = 0; i < itemsCount; i++)
            {
                var tokens = Console.ReadLine().Split(' ').ToArray();
                var price = double.Parse(tokens[0]);
                var weight = double.Parse(tokens[2]);
                var item = new Item(price, weight);
                items.Add(item);
            }

            items.Sort();

            var takenItems = new List<Item>();
            var totalPrice = 0.0;

            foreach (var item in items)
            {
                if (capacity == 0)
                {
                    break;
                }
                
                if (item.Weight < capacity)
                {
                    item.Fraction  = 100;
                    capacity -= item.Weight;
                }
                else
                {
                    item.Fraction  = 100 * capacity / item.Weight;
                    capacity = 0;
                }

                takenItems.Add(item);
                Console.WriteLine(item);
                totalPrice += item.Fraction * item.Price / 100;
            }
            
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }

        public class Item : IComparable<Item>
        {
            public Item(double price, double weight)
            {
                this.Price = price;
                this.Weight = weight;
                this.Value = this.Price / this.Weight;
            }

            public double Price { get; set; }
            public double Weight { get; set; }
            public double Value { get; set; }
            public double Fraction { get; set; }

            public int CompareTo(Item other)
            {
                return other.Value.CompareTo(this.Value);
            }

            public override string ToString()
            {
                var result = this.Fraction==100.00 ?this.Fraction.ToString():this.Fraction.ToString("F2");
                return  $"Take {result}% of item with price {this.Price:f2} and weight {this.Weight:f2}";
            }
        }
    }
}
