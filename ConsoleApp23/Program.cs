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
            
        }
        private static void varposition2(out int lastFoodTime, out Random randomNumberscreater)
        {
            randomNumberscreater = returnnumber();
            System.Console.BufferHeight = System.Console.WindowHeight;
            lastFoodTime = System.Environment.TickCount;
        }

    }
            