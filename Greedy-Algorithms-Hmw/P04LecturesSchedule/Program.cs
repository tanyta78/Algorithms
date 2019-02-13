namespace P04LecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var lecturesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            var lectures = new List<Lecture>();

            for (int i = 0; i < lecturesCount; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var name = tokens[0].Substring(0,tokens[0].Length-1);
                var start = int.Parse(tokens[1]);
                var end = int.Parse(tokens[3]);

                var lecture = new Lecture(name,start,end);
                lectures.Add(lecture);
            }

            var selectedLectures = new List<Lecture>();

            while (lectures.Count>0)
            {
                var current = lectures.OrderBy(l=>l).First();

                selectedLectures.Add(current);
                lectures.RemoveAll(l => l.Start < current.End);
            }

            Console.WriteLine($"Lectures ({selectedLectures.Count}):");

            foreach(var lecture in selectedLectures)
            {
                Console.WriteLine($"{lecture.Start}-{lecture.End} -> {lecture.Name}");
            }
        }

        public class Lecture : IComparable<Lecture>
        {
            public Lecture(string name, int start, int end)
            {
                this.Name = name;
                this.Start = start;
                this.End = end;
            }

            public string Name { get; set; }
            public int Start { get; set; }
            public int End { get; set; }

            public int CompareTo(Lecture other)
            {
                return this.End.CompareTo(other.End);
            }
        }
    }
}
