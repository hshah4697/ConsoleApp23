//console libraries//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;//for threading//

namespace SnakeGame//game name Snakegame//
{
    // internal structure for snakegame//
    internal struct Position
    {
        // global declaration of row, col//
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    class Program
    {
        // constant variable//
        private const int V = 0;

        static void Main(string[] args)
        {
            byte right, left, down, up;
            int endlunchTime, foodexitTime, reverseend, way;
            double sleepTime;
            // internal extract method for value assignment//
            static void assignment(out byte right, out byte left, out byte down, out byte up, out int lastFoodTime, out int foodexitTime, out int negativePoints, out double sleepTime, out int direction)
            {
                right = V;//right move//
                left = 1;// left move//
                down = 2;//down move//
                up = 3;// upmove//
                lastFoodTime = 0;
                foodexitTime = 5000;
                negativePoints = 0;
                sleepTime = 50;
                direction = right;// starting in the right direction//
            }
            assignment(out right, out left, out down, out up, out endlunchTime, out foodexitTime, out reverseend, out sleepTime, out way);
            Random NumbersCreater;
            varposition2(out endlunchTime, out NumbersCreater);
            List<Position> problems = positionarrangement();
            problemposistion(problems);

            Queue<Position> snakeobjects;
            Position food;
            NewMethod3(NumbersCreater, problems, out snakeobjects, out food);
            varposition(snakeobjects);

            movement(right, left, down, up, ref endlunchTime, foodexitTime, ref reverseend, ref sleepTime, ref way, NumbersCreater, problems, snakeobjects, ref food);
        }
        //method for position arrangement//
        private static List<Position> positionarrangement()
        {
            //position stroed in list//
            return new List<Position>()
            {
                new Position(11, 11),
                new Position(12, 25),
                new Position(5, 9),
                new Position(20, 20),
                new Position(6, 10),
            };
        }
        // method for randomnumber call//
        private static Random returnnumber()
        {
            return new System.Random();
        }
        private static Queue<Position> queuerange()
        {
            return new Queue<Position>();
        }
        //method for snakefood and its notation//
        private static void NewMethod3(Random randomNumberscreater, List<Position> problems, out Queue<Position> snakeobjects, out Position food)
        {
            snakeobjects = queuerange();
            // for loop for position of food//
            for (int j = 0; j <= 5; j++)
            {
                snakeobjects.Enqueue(new Position(0, j));
            }
            food = foodmethod(randomNumberscreater, problems, snakeobjects);
            System.Console.SetCursorPosition(food.col, food.row);// cursor position//
            System.Console.ForegroundColor = System.ConsoleColor.Red;// provide color to food//
            System.Console.Write("$");
        }
        //change food position//
        private static Position foodmethod(Random randomNumberscreater, List<Position> problems, Queue<Position> snakeobjects)
        {
            Position food;
            do
            {
                food = new Position(randomNumberscreater.Next(0, System.Console.WindowHeight),
                    randomNumberscreater.Next(0, System.Console.WindowWidth));
            }
            while (snakeobjects.Contains(food) || problems.Contains(food));
            return food;
        }
        // snake movement direction//
        private static void movement(byte right, byte left, byte down, byte up, ref int endFoodTime, int foodexitTime, ref int reverseend, ref double sleepTime, ref int way, Random randomNumberscreater, List<Position> problems, Queue<Position> snakeobjects, ref Position food)
        {
            NewMethod(right, left, down, up, ref endFoodTime, foodexitTime, ref reverseend, ref sleepTime, ref way, randomNumberscreater, problems, snakeobjects, ref food);

            static void NewMethod(byte right, byte left, byte down, byte up, ref int endFoodTime, int foodexitTime, ref int reverseend, ref double sleepTime, ref int way, Random randomNumberscreater, List<Position> problems, Queue<Position> snakeobjects, ref Position food)
            {
                while (true)
                {
                    reverseend++;
                    // nested if loop//
                    if (System.Console.KeyAvailable)
                    {
                        System.ConsoleKeyInfo userInput = System.Console.ReadKey();
                        if (userInput.Key == System.ConsoleKey.LeftArrow)
                        {
                            if (way != right) way = left;//lest move//
                        }
                        if (userInput.Key == System.ConsoleKey.RightArrow)
                        {
                            if (way != left) way = right;//right move//
                        }
                        if (userInput.Key == System.ConsoleKey.UpArrow)
                        {
                            if (way != down) way = up; //upside move//
                        }
                        if (userInput.Key == System.ConsoleKey.DownArrow)
                        {
                            if (way != up) way = down;// downside move//
                        }
                    }
                    //head poition direction//
                    Position snakeHead = snakeobjects.Last();

                    Position[] directions = new Position[]
                    {
                new Position(0, 1), // right
                new Position(0, -1), // left
                new Position(1, 0), // down
                new Position(-1, 0), // up
                    };
                    Position nextDirection = directions[way];

                    Position snakeNewHead = new Position(snakeHead.row + nextDirection.row,
                        snakeHead.col + nextDirection.col);

                    if (snakeNewHead.col < 0) snakeNewHead.col = System.Console.WindowWidth - 1;
                    if (snakeNewHead.row < 0) snakeNewHead.row = System.Console.WindowHeight - 1;
                    if (snakeNewHead.row >= System.Console.WindowHeight) snakeNewHead.row = 0;
                    if (snakeNewHead.col >= System.Console.WindowWidth) snakeNewHead.col = 0;

                    if (snakeobjects.Contains(snakeNewHead) || problems.Contains(snakeNewHead))
                    {
                        System.Console.SetCursorPosition(0, 0);
                        System.Console.ForegroundColor = System.ConsoleColor.Red;
                        //notation for game ending after snake touch the #//
                        System.Console.WriteLine("Game over!");
                        int userPoints = (snakeobjects.Count - 6) * 100 - reverseend;
                        //if (userPoints < 0) userPoints = 0;
                        userPoints = System.Math.Max(userPoints, 0);
                        System.Console.WriteLine("Your points are: {0}", userPoints);
                        return;
                    }
                    // cursor position//
                    System.Console.SetCursorPosition(snakeHead.col, snakeHead.row);
                    System.Console.ForegroundColor = System.ConsoleColor.DarkGray;
                    System.Console.Write("*");

                    snakeobjects.Enqueue(snakeNewHead);
                    System.Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    System.Console.ForegroundColor = System.ConsoleColor.Gray;
                    if (way == right) System.Console.Write(">");
                    if (way == left) System.Console.Write("<");
                    if (way == up) System.Console.Write("^");
                    if (way == down) System.Console.Write("v");


                    if (snakeNewHead.col != food.col || snakeNewHead.row != food.row)
                    {
                        // moving...//
                        Position last = snakeobjects.Dequeue();
                        System.Console.SetCursorPosition(last.col, last.row);
                        System.Console.Write(" ");
                    }
                    else
                    {
                        // feeding the snake//
                        food = foodposition(randomNumberscreater, problems, snakeobjects);
                        endFoodTime = System.Environment.TickCount;
                        System.Console.SetCursorPosition(food.col, food.row);
                        System.Console.ForegroundColor = System.ConsoleColor.Red;
                        System.Console.Write("$");
                        sleepTime--;

                        Position obstacle = new Position();
                        obstacle = problemofobject(randomNumberscreater, problems, snakeobjects, food);
                        problems.Add(obstacle);
                        System.Console.SetCursorPosition(obstacle.col, obstacle.row);
                        System.Console.ForegroundColor = System.ConsoleColor.Cyan;
                        System.Console.Write("=");
                    }

                    NewMethod7(ref endFoodTime, foodexitTime, ref reverseend, randomNumberscreater, problems, snakeobjects, ref food);

                    System.Console.SetCursorPosition(food.col, food.row);
                    System.Console.ForegroundColor = System.ConsoleColor.Red;
                    System.Console.Write("$");

                    sleepTime -= 0.02;

                    Thread.Sleep((int)sleepTime);
                }
            }
        }
        // obstacles position method//
        private static Position problemofobject(Random randomNumberscreater, List<Position> problems, Queue<Position> snakeobjects, Position food)
        {
            Position obstacle;
            obstacle = NewMethod(randomNumberscreater, problems, snakeobjects, food);
            return obstacle;

            static Position NewMethod(Random randomNumberscreater, List<Position> problems, Queue<Position> snakeobjects, Position food)
            {
                Position obstacle;
                do
                {
                    obstacle = new Position(randomNumberscreater.Next(0, System.Console.WindowHeight),
                        randomNumberscreater.Next(0, System.Console.WindowWidth));
                }
                while (snakeobjects.Contains(obstacle) ||
      problems.Contains(obstacle) ||
      (food.row != obstacle.row && food.col != obstacle.row));
                return obstacle;
            }
        }
        private static Position foodposition(Random randomNumberscreater, List<Position> problems, Queue<Position> snakeobjects)
        {
            Position food;
            food = NewMethod(randomNumberscreater, problems);
            return food;
            // internal method//
            static Position NewMethod(Random randomNumberscreater, List<Position> problems)
            {
                Position food;
                // do-while loop for new position of food//
                do
                {
                    food = new Position(randomNumberscreater.Next(0, System.Console.WindowHeight),
                        randomNumberscreater.Next(0, System.Console.WindowWidth));
                }
                while (problems.Contains(food) || problems.Contains(food));
                return food;
            }
        }
        private static void NewMethod7(ref int lastFoodTime, int foodDissapearTime, ref int negativePoints, Random randomNumbersGenerator, List<Position> obstacles, Queue<Position> snakeElements, ref Position food)
        {
            if (System.Environment.TickCount - lastFoodTime >= foodDissapearTime)
            {
                negativePoints = negativePoints + 50;
                System.Console.SetCursorPosition(food.col, food.row);
                System.Console.Write(" ");
                do
                {
                    food = new Position(randomNumbersGenerator.Next(0, System.Console.WindowHeight),
                        randomNumbersGenerator.Next(0, System.Console.WindowWidth));
                }
                while (snakeElements.Contains(food) || obstacles.Contains(food));
                lastFoodTime = System.Environment.TickCount;
            }
        }
        //method for # problems position in game//
        private static void problemposistion(List<Position> problems)
        {
            foreach (Position obstacle in problems)
            {
                System.Console.ForegroundColor = System.ConsoleColor.Cyan;
                System.Console.SetCursorPosition(obstacle.col, obstacle.row);
                System.Console.Write("#");
            }
        }
        private static void varposition(Queue<Position> snakeobjects)
        {
            foreach (var position in snakeobjects)
            {
                System.Console.SetCursorPosition(position.col, position.row);
                System.Console.ForegroundColor = System.ConsoleColor.DarkGray;
                System.Console.Write("*");
            }
        }
        private static void varposition2(out int lastFoodTime, out Random randomNumberscreater)
        {
            randomNumberscreater = returnnumber();
            System.Console.BufferHeight = System.Console.WindowHeight;
            lastFoodTime = System.Environment.TickCount;
        }

    }
}
