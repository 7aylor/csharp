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

        public struct position
        {
            public int x;
            public int y;
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            char [,] level = new char[WIDTH, HEIGHT];
            position coords = new position();

            coords.x = 0;
            coords.y = 4;

            buildLevel(ref level);
            printLevel(level, coords.x, coords.y);

            char key = Console.ReadKey(true).KeyChar;

            while (key != 'x')
            {
                if (key == 'd')
                {
                    goRight(ref level, ref coords.x, coords.y);
                    printLevel(level, coords.x, coords.y);
                }
                if (key == 'a')
                {
                    goLeft(ref level, ref coords.x, coords.y);
                    printLevel(level, coords.x, coords.y);
                }
                if (key == 'w')
                {
                    goUp(ref level, coords.x, ref coords.y);
                    printLevel(level, coords.x, coords.y);
                }
                if (key == 's')
                {
                    goDown(ref level, coords.x, ref coords.y);
                    printLevel(level, coords.x, coords.y);
                }
                key = Console.ReadKey(true).KeyChar;
            }

            

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
            try
            {
                x++;
                level[x - 1, y] = ' ';
                level[x, y] = '*';
            }
            catch
            {
                return;
            }
            
        }

        static void goLeft(ref char[,] level, ref int x, int y)
        {
            try
            {
                x--;
                level[x + 1, y] = ' ';
                level[x, y] = '*';
            }
            catch
            {
                return;
            }
        }

        static void goUp(ref char[,] level, int x, ref int y)
        {
            try
            {
                y--;
                level[x, y + 1] = ' ';
                level[x, y] = '*';
            }
            catch
            {
                return;
            }
        }

        static void goDown(ref char[,] level, int x, ref int y)
        {
            try
            {
                y++;
                level[x, y - 1] = ' ';
                level[x, y] = '*';
            }
            catch
            {
                return;
            }
        }

        static void printLevel(char[,] level, int x, int y)
        {
            Console.Clear();
            for (int i = 0; i < HEIGHT; i++)
            {
                for(int j = 0; j < WIDTH; j++)
                {
                    if(j == x && i == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(level[j, i]);
                }
                Console.WriteLine();
            } 
        }
    }
}

