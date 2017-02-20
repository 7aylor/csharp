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

            coords.x = 1;
            coords.y = 4;

            buildLevel(ref level);
            printLevel(level, coords.x, coords.y);

            char key = Console.ReadKey(true).KeyChar;

            addElement(ref level, '|', 4, 4);

            while (key != 'x')
            {
                if (key == 'd')
                {
                    goRight(ref level, ref coords.x, coords.y);
                }
                if (key == 'a')
                {
                    goLeft(ref level, ref coords.x, coords.y);
                }
                if (key == 'w')
                {
                    goUp(ref level, coords.x, ref coords.y);
                }
                if (key == 's')
                {
                    goDown(ref level, coords.x, ref coords.y);
                }
                key = Console.ReadKey(true).KeyChar;
            }
        }

        static void addElement(ref char[,] level, char element, int x, int y)
        {
            level[x, y] = element;
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
            if (x < WIDTH - 2)
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
            if (x > 1)
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
            if(y > 1)
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
            if (y < HEIGHT - 2)
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
    }
}

