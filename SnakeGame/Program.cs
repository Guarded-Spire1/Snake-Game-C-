
using System.Collections.Generic;

namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int BORDER_WIDTH = 40;
            const int BORDER_HEIGHT = 20;

            Random rnd = new Random();
            var coord = new Coord(BORDER_WIDTH, BORDER_HEIGHT);
            var food = new Coord(rnd.Next(1, BORDER_WIDTH - 1), rnd.Next(1, BORDER_HEIGHT - 1));
            var snake = new Coord(10, 10);
            var snakeTale = new List<Coord>(760);
            snakeTale.Add(new Coord(9, 10));
            var taleLength = 1;


            char cachedDirection = default(char);
            while (true)
            {
                Console.Clear();

                if (Console.KeyAvailable)
                {
                    char direction = Console.ReadKey(intercept: true).KeyChar;

                    if (direction != cachedDirection)
                    {
                        switch (direction)
                        {
                            case 'w':
                                if (cachedDirection == 's') break;
                                else cachedDirection = direction;
                                break;
                            case 'd':
                                if (cachedDirection == 'a') break;
                                else cachedDirection = direction;
                                break;
                            case 's':
                                if (cachedDirection == 'w') break;
                                else cachedDirection = direction;
                                break;
                            case 'a':
                                if (cachedDirection == 'd') break;
                                else cachedDirection = direction;
                                break;

                        }
                    }
                }
                snake.ChangeCoords((Direction)cachedDirection);



                for (int y = 0; y <= coord.Y; y++)
                {
                    for (int x = 0; x <= coord.X; x++)
                    {
                        if (x == 0 || y == 0 || x == coord.X || y == coord.Y)
                            Console.Write("#");
                        else if (snake.IsAt(x, y))
                            Console.Write("■");
                        else if (snakeTale.Any(t => t.IsAt(x, y)))
                            Console.Write("■");
                        else if (food.IsAt(x, y))
                            Console.Write("a");
                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                snakeTale.Insert(0, new Coord(snake.X, snake.Y));
                if (snake.Equals(food))
                {
                    taleLength++;
                    food = new Coord(rnd.Next(1, BORDER_WIDTH - 1), rnd.Next(1, BORDER_HEIGHT - 1));
                }
                else snakeTale.RemoveAt(snakeTale.Count - 1);

                if (snake.X == coord.X || snake.Y == coord.Y || snake.X == 0 || snake.Y == 0) return;

                if (snakeTale.Skip(1).Any(bodyPart => snake.Equals(bodyPart))) return;

                Thread.Sleep(100);
            }

        }

    }
}
