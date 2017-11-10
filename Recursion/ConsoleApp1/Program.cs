using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new DateTime(2017, 10, 11, 11, 23, 0).ToString("MMM"));
            var x = 10;
            var y = 5;
            var result = x > 10 ? y > 3 ? "test1" : "test2" : "test3";
            Console.WriteLine(result);
        }

        static void Increment(int number)
        {
            ++number;
        }
    }
}
