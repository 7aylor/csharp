using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scroller
{
    class Program
    {
        const int WIDTH = 64;
        const int HEIGHT = 6;
        const char PLAYER = '*';
        const ConsoleColor obstacleColor = ConsoleColor.Green;

        class Player
        {
            public int x;
            public int y;
            public ConsoleColor color;

            public Player(int x, int y, ConsoleColor color)
            {
                this.x = x;
                this.y = y;
                this.color = color;
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            char [,] level = new char[WIDTH, HEIGHT];


            Player player = new Player(1, 4, ConsoleColor.Red);

            buildLevel(ref level);
            printLevel(level, player.x, player.y);

            addElement(ref level, PLAYER, player.x, player.y, player.color);
            addElement(ref level, '|', 4, 4, obstacleColor);
            addElement(ref level, '=', 3, 3, obstacleColor);

            ConsoleKey key = Console.ReadKey(true).Key;

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
                key = Console.ReadKey(true).Key;
            }
        }

        static void addElement(ref char[,] level, char element, int x, int y, ConsoleColor color)
        {
            level[x, y] = element;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(element);
        }

        static void buildLevel(ref char[,] level)
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
            if(y > 1 && !checkObstacle(level, x, y - 1))
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

        static void printLevel(char[,] level, int x, int y)
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for(int j = 0; j < WIDTH; j++)
                {
                    Console.Write(level[j, i]);
                }
                Console.Write('\n');
            } 
        }

        static bool checkObstacle(char[,] level, int x, int y)
        {
            if (level[x, y] == '|' || level[x,y] == '-' || level[x, y] == '_' || level[x, y] == '=')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

