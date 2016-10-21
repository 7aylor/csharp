using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 10;
            Console.WriteLine("\t***PYRAMID 1***");
            for(int i = 0; i < max; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n\n\t***PYRAMID 2***");
            for (int i = max; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n\n\t***PYRAMID 3***");
            for (int i = 0; i < max; i++)
            {
                int numSpaces = max - i ;
                for(int k = 0; k < numSpaces; k++)
                {
                    Console.Write(" ");
                }
                int numStars = max - numSpaces;

                for (int j = 0; j < numStars; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\n\n\t***PYRAMID 4***");
            for (int i = max; i > 0; i--)
            {
                int numSpaces = max - i;
                for (int k = 0; k < numSpaces; k++)
                {
                    Console.Write(" ");
                }
                int numStars = max - numSpaces;

                for (int j = 0; j < numStars; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\n\n\t***pyramid 5***");
            for (int i = 0; i < max; i++)
            {
                int numSpaces = (max - i);
                for (int k = 0; k < numSpaces; k++)
                {
                    Console.Write(" ");
                }
                int numStars = (i * 2) + 1;

                for (int j = 0; j < numStars; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
