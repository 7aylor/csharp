using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************It's All Greek to Me!*************\n\n");
            Console.WriteLine("Input: two sets of x and y coordinates representing points.");
            Console.WriteLine("Output: the angle and distance between the two points\n\n");
            Console.WriteLine("Please Input the first x and y pair");

            Console.Write("First X: ");
            string userIn = Console.ReadLine();
            decimal x1 = checkInput(userIn);

            Console.Write("First Y: ");
            userIn = Console.ReadLine();
            decimal y1 = checkInput(userIn);

            Console.WriteLine("First Pair: ({0}, {1})\n", x1, y1);

            Console.WriteLine("Please Input the second x and y pair");

            Console.Write("Second X: ");
            userIn = Console.ReadLine();
            decimal x2 = checkInput(userIn);

            Console.Write("Second Y: ");
            userIn = Console.ReadLine();
            decimal y2 = checkInput(userIn);

            Console.WriteLine("Second Pair: ({0}, {1})\n", x2, y2);



            Console.ReadKey();
        }

        static decimal checkInput(string input)
        {
            decimal output;
            while(!decimal.TryParse(input, out output))
            {
                Console.Write("Incorrect input, please try again: ");
                input = Console.ReadLine();
            }

            return output;
        }
    }
}
