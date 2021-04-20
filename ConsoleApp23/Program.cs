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
            
            System.Console.SetCursorPosition(food.col, food.row);// cursor position//
            System.Console.ForegroundColor = System.ConsoleColor.Red;// provide color to food//
            System.Console.Write("$");
        }
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
        private static void varposition2(out int lastFoodTime, out Random randomNumberscreater)
        {
            randomNumberscreater = returnnumber();
            System.Console.BufferHeight = System.Console.WindowHeight;
            lastFoodTime = System.Environment.TickCount;
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

    }
            