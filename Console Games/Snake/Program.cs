using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scroller
{
    class Program
    {
        const ConsoleColor obstacleColor = ConsoleColor.Green;
        const int WIDTH = 64;
        const int HEIGHT = 16;
        enum Direction { up, down, left, right }

        class Player
        {
            int x;
            int y;
            Direction direction;
            char symbol = 'D';
            ConsoleColor color;
            int length;
            Random randomDirection = new Random();

            public Player(int x, int y, ConsoleColor color)
            {
                this.x = x;
                this.y = y;
                this.color = color;
                this.length = 1;

                int randResult = randomDirection.Next(4);

                switch (randResult)
                {
                    case 0:
                        direction = Direction.up;
                        break;
                    case 1:
                        direction = Direction.down;
                        break;
                    case 2:
                        direction = Direction.right;
                        break;
                    case 3:
                        direction = Direction.left;
                        break;
                }
            }
            #region//getters and setters
            public int X
            {
                get
                {
                    return this.x;
                }
                set
                {
                    this.x = value;
                }
            }
            public int Y
            {
                get
                {
                    return this.y;
                }
                set
                {
                    this.y = value;
                }
            }
            public Direction Direction
            {
                get
                {
                    return this.direction;
                }
            }
            public char Symbol
            {
                get
                {
                    return this.symbol;
                }
            }
            public ConsoleColor Color
            {
                get
                {
                    return this.color;
                }
                set
                {
                    this.color = value;
                }
            }
            public int Length
            {
                get
                {
                    return this.length;
                }
                set
                {
                    this.length = value;
                }
            }
            #endregion

            public void eat()
            {
                this.length++;
            }
        }

        class Apple
        {
            int x;
            int y;
            char symbol = '*';
            ConsoleColor color;
            Random locX = new Random();
            Random locY = new Random();

            public Apple(int x, int y, ConsoleColor color)
            {
                this.x = x;
                this.y = y;
                this.color = color;
            }

            #region//getters and setters
            public int X
            {
                get
                {
                    return this.x;
                }
                set
                {
                    this.x = value;
                }
            }
            public int Y
            {
                get
                {
                    return this.y;
                }
                set
                {
                    this.y = value;
                }
            }
            public char Symbol
            {
                get
                {
                    return this.symbol;
                }
            }
            public ConsoleColor Color
            {
                get
                {
                    return this.color;
                }
                set
                {
                    this.color = value;
                }
            }
            #endregion

            public void spawnApple()
            {
                this.x = locX.Next(0, WIDTH);
                this.y = locY.Next(0, HEIGHT);
            }
        }

        class Level
        {
            char[,] level = new char[WIDTH, HEIGHT];

            public Level()
            {
                //build top row
                for (int i = 1; i < WIDTH - 1; i++)
                {
                    level[i, 0] = '=';
                }

                //sides
                for (int i = 0; i < HEIGHT; i++)
                {
                    level[0, i] = '|';
                    level[WIDTH - 1, i] = '|';
                }


                //build bottom row
                for (int i = 1; i < WIDTH - 1; i++)
                {
                    level[i, HEIGHT - 1] = '=';
                }
            }

            public void printLevel(Player player, Apple apple)
            {
                for (int i = 0; i < HEIGHT; i++)
                {
                    for (int j = 0; j < WIDTH; j++)
                    {
                        if(level[j, i] == player.Symbol)
                        {
                            Console.ForegroundColor = player.Color;
                            Console.Write(this.level[j, i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (level[j, i] == apple.Symbol)
                        {
                            Console.ForegroundColor = apple.Color;
                            Console.Write(this.level[j, i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write(this.level[j, i]);
                        }
                    }
                    Console.Write('\n');
                }
            }

            public void addElement(char element, int x, int y, ConsoleColor color)
            {
                level[x, y] = element;
                //Console.ForegroundColor = color;
                //Console.SetCursorPosition(x, y);
                //Console.Write(element);
                //Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Level level = new Level();
            Player player = new Player(WIDTH / 2, HEIGHT / 2, ConsoleColor.Green);
            Apple apple = new Apple(10, 10, ConsoleColor.Red);

            level.addElement(player.Symbol, player.X, player.Y, player.Color);
            level.addElement(apple.Symbol, apple.X, apple.Y, apple.Color);

            level.printLevel(player, apple);

            //buildLevel(ref level);
            //printLevel(level, player.x, player.y);
            //addElement(ref level, APPLE, 10, 10, ConsoleColor.Green);
            //addElement(ref level, APPLE, 10, 10, ConsoleColor.Green);

            //Timer t = new Timer(callBackTimer(player, apple, null, 0, 1000);

            ConsoleKey key = Console.ReadKey(true).Key;
            #region //presses
            /*
            while (key != ConsoleKey.X)
            {
                if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
                {
                    goRight(ref level, ref player.x, player.y);
                }
                if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                {
                    goLeft(ref level, ref player.x, player.y);
                }
                if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    goUp(ref level, player.x, ref player.y);
                }
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    goDown(ref level, player.x, ref player.y);
                }

                if (player.x == 10 && player.y == 10)
                {
                    player.eat();
                }
                */
                key = Console.ReadKey(true).Key;
            }

            #endregion
        /*
        static void goRight(ref char[,] level, ref int x, int y)
        {
            if (x < WIDTH - 2 && !checkObstacle(level, x + 1, y))
            {
                x++;
                level[x - 1, y] = ' ';
                Console.SetCursorPosition(x - 1, y);
                Console.Write(' ');

                Console.ForegroundColor = ConsoleColor.Red;
                level[x, y] = PLAYER;
                Console.SetCursorPosition(x, y);
                Console.Write(PLAYER);
            }
        }

        static void goLeft(ref char[,] level, ref int x, int y)
        {
            if (x > 1 && !checkObstacle(level, x - 1, y))
            {
                x--;
                level[x + 1, y] = ' ';
                Console.SetCursorPosition(x + 1, y);
                Console.Write(' ');

                Console.ForegroundColor = ConsoleColor.Red;
                level[x, y] = PLAYER;
                Console.SetCursorPosition(x, y);
                Console.Write(PLAYER);
            }
        }

        static void goUp(ref char[,] level, int x, ref int y)
        {
            if (y > 1 && !checkObstacle(level, x, y - 1))
            {
                y--;
                level[x, y + 1] = ' ';
                Console.SetCursorPosition(x, y + 1);
                Console.Write(' ');

                Console.ForegroundColor = ConsoleColor.Red;
                level[x, y] = PLAYER;
                Console.SetCursorPosition(x, y);
                Console.Write(PLAYER);
            }
        }

        static void goDown(ref char[,] level, int x, ref int y)
        {
            if (y < HEIGHT - 2 && !checkObstacle(level, x, y + 1))
            {
                y++;
                level[x, y - 1] = ' ';
                Console.SetCursorPosition(x, y - 1);
                Console.Write(' ');

                level[x, y] = PLAYER;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x, y);
                Console.Write(PLAYER);
            }
        }

        static bool checkObstacle(char[,] level, int x, int y)
        {
            if (level[x, y] == '|' || level[x, y] == '-' || level[x, y] == '_' || level[x, y] == '=')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
        static void callBackTimer(Player player, Apple apple)
        {
            if(player.Direction == Direction.up)
            {
                player.Y--;
            }
            else if (player.Direction == Direction.down)
            {
                player.Y++;
            }
            else if (player.Direction == Direction.left)
            {
                player.X--;
            }
            else if (player.Direction == Direction.right)
            {
                player.X++;
            }
        }

    }
}

