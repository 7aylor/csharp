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
            //Tell users purpose of program
            Console.WriteLine("\t*************It's All Greek to Me!*************\n\n");
            Console.WriteLine("Input: two sets of x and y coordinates representing points.");
            Console.WriteLine("Output: the angle and distance between the two points\n\n");
            Console.WriteLine("Please Input the first x and y pair");

            //get x1 and convert to double
            Console.Write("Point 1 X: ");
            double x1 = double.Parse(Console.ReadLine());

            //get y1 and convert to double
            Console.Write("Point 1 Y: ");
            double y1 = double.Parse(Console.ReadLine());

            //print out the first point's coordinates, then prompt for the next
            Console.WriteLine("First Pair: ({0}, {1})\n", x1, y1);
            Console.WriteLine("Please Input the second x and y pair");

            //get x2 and convert to double
            Console.Write("Point 2 X: ");
            double x2 = double.Parse(Console.ReadLine());

            //get y2 and convert to double
            Console.Write("Point 2 Y: ");
            double y2 = double.Parse(Console.ReadLine());

            //print out the second point's coordinates
            Console.WriteLine("Second Pair: ({0}, {1})\n", x2, y2);

            //compute distance and angle
            double dist = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y2 - y1, 2));
            double angle = Math.Atan2((y2 - y1), (x2 - x1)) * 180 / Math.PI;

            //print results with three floating points
            Console.WriteLine("Distance between points: " + dist.ToString("F3"));
            Console.WriteLine("Angle between points: " + angle.ToString("F3"));

            //prompt user to press a key to exit
            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
