namespace P02ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Task> tasks = new List<Task>();

        public static void Main(string[] args)
        {
            var tasksCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            for (int i = 0; i < tasksCount; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var value = int.Parse(tokens[0]);
                var deadLine = int.Parse(tokens[2]);

                var task = new Task(value, deadLine);
                tasks.Add(task);
            }
            
            var endTime = tasks.Max(t => t.Deadline);
            var selectedTasks = new List<Task>();

            for (int step = 0; step < endTime; step++)
            {
                var mostValuableTask = tasks
                                        .Where(t => !t.IsCompleted && t.Deadline > step)
                                        .OrderByDescending(t => t.Value / (t.Deadline - step))
                                        .First();

                mostValuableTask.IsCompleted = true;

                selectedTasks.Add(mostValuableTask);
            }

            Console.WriteLine($"Optimal schedule: {String.Join(" -> ", selectedTasks.Select(t => t.Id))}");
            Console.WriteLine($"Total value: {selectedTasks.Sum(t => t.Value)}");

        }

        public class Task
        {
            static int id = 1;

            public Task(int value, int deadline)
            {
                this.Value = value;
                this.Deadline = deadline;
            }

            public int Id { get; set; } = id++;
            public int Value { get; set; }
            public int Deadline { get; set; }

            public bool IsCompleted { get; set; } = false;

        }
    }
}
