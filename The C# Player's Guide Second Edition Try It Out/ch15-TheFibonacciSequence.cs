using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFibonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = Fibonacci(10);
            Console.Write(result);
            Console.ReadKey();

        }

        static int Fibonacci(int num)
        {
            if(num == 1 || num == 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(num - 1) + Fibonacci(num - 2);
            }
        }
    }
}
