namespace ActivitySelection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var activities = new List<Activity>
            {
                new Activity(12, 14),
                new Activity(1, 4),
                new Activity(2,13),
                new Activity(3,5),
                new Activity(8,12),
                new Activity(0,6),
                new Activity(8,11),
                new Activity(5,7),
                new Activity(6,10),
                new Activity(3,8),
                new Activity(5,9)
            };

            activities = activities.OrderBy(a => a.End).ToList();

            var lastActivity = activities[0];
            Console.WriteLine(lastActivity);

            while (activities.Count > 0)
            {
                var current = activities.First();
                activities.Remove(current);

                if (current.Start>=lastActivity.End)
                {
                    Console.WriteLine(current);
                    lastActivity = current;
                }
            }
        }
    }

    public class Activity
    {
        public Activity(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public int Start { get; set; }
        public int End { get; set; }

        public override string ToString()
        {
            return $"(Start = {this.Start} Finish = {this.End})";
        }
    }
}
