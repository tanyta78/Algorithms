namespace P01Snakes
{
    using System;
    using System.Collections.Generic;

    //Note: When generating the snakes, there may be different correct answers. When testing your solution, priority should be as follows: R -> D -> L -> U. The visual example above for n = 5 does NOT follow this priority.

    public class Program
    {
        private static int snakeLength;
        private static int count;
        static HashSet<string> visited = new HashSet<string>();
        static HashSet<string> snakes = new HashSet<string>();
        private static char[] currentSnake;

        public static void Main(string[] args)
        {
            snakeLength = int.Parse(Console.ReadLine());
            currentSnake = new char[snakeLength];
            CreateSnake(0, 0, 0, 'S');
            Console.WriteLine($"Snakes count = {count}");
        }

        private static void CreateSnake(int index, int row, int col, char direction)
        {
            if (index >= snakeLength)
            {
                var snake = new string(currentSnake);
                if (!snakes.Contains(snake))
                {
                    Console.WriteLine(snake);
                    count++;
                    MarkSnake(snake);
                }
            }
            else
            {
                var currentCell = row + " " + col;
                if (!visited.Contains(currentCell))
                {

                    visited.Add(currentCell);
                    currentSnake[index] = direction;
                    CreateSnake(index + 1, row, col + 1, 'R');
                    CreateSnake(index + 1, row + 1, col, 'D');
                    CreateSnake(index + 1, row, col - 1, 'L');
                    CreateSnake(index + 1, row - 1, col, 'U');

                    visited.Remove(currentCell);
                }
            }
        }

        private static void MarkSnake(string snake)
        {


            string flipped = Flip(snake);
            string reversed = Reverse(snake);
            string flippedReversed = Reverse(flipped);

            for (int i = 0; i < 4; i++)
            {
                snake = Rotate(snake);
                snakes.Add(snake);
            }

            for (int i = 0; i < 4; i++)
            {
                flipped = Rotate(flipped);
                snakes.Add(flipped);
            }

            for (int i = 0; i < 4; i++)
            {
                reversed = Rotate(reversed);
                snakes.Add(reversed);
            }

            for (int i = 0; i < 4; i++)
            {
                flippedReversed = Rotate(flippedReversed);
                snakes.Add(flippedReversed);
            }
        }

        private static string Rotate(string snake)
        {
            char[] rotated = new char[snake.Length];
            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'R': rotated[i] = 'D'; break;
                    case 'D': rotated[i] = 'L'; break;
                    case 'L': rotated[i] = 'U'; break;
                    case 'U': rotated[i] = 'R'; break;
                    default: rotated[i] = snake[i]; break;
                }
            }

            return new string(rotated);
        }

        private static string Reverse(string snake)
        {
            char[] reversed = new char[snakeLength];
            reversed[0] = 'S';
            for (int i = 1; i < snakeLength; i++)
            {
                reversed[i] = snake[snakeLength - i];
            }
            return new string(reversed);
        }

        private static string Flip(string snake)
        {
            char[] flipped = new char[snake.Length];
            for (int i = 0; i < snake.Length; i++)
            {
                if (snake[i] == 'U')
                {
                    flipped[i] = 'D';
                }
                else if (snake[i] == 'D')
                {
                    flipped[i] = 'U';
                }
                else
                {
                    flipped[i] = snake[i];
                }
            }

            return new string(flipped);
        }
    }
}
