using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            float firstNum;
            float secondNum;
            char operation;
            float result;
            char continueLoop = 'y';

            while (continueLoop == 'y' || continueLoop == 'Y')
            {
                Console.WriteLine("\t\t***Calculator***");
                Console.Write("Number 1: ");
                firstNum = Convert.ToSingle(Console.ReadLine());
                Console.Write("Number 2: ");
                secondNum = Convert.ToSingle(Console.ReadLine());
                Console.Write("Operator + - / * ^ %: ");
                operation = Convert.ToChar(Console.ReadLine());

                switch (operation)
                {
                    case '+':
                        result = firstNum + secondNum;
                        break;
                    case '-':
                        result = firstNum - secondNum;
                        break;
                    case '*':
                        result = firstNum * secondNum;
                        break;
                    case '/':
                        result = firstNum / secondNum;
                        break;
                    case '^':
                        result = firstNum;
                        for (short i = 0; i < secondNum; i++)
                        {
                            result *= firstNum;
                        }
                        break;
                    case '%':
                        result = firstNum % secondNum;
                        break;
                    default:
                        Console.WriteLine("Unkown operator.");
                        return;

                }
                Console.Write("Result: ");
                Console.WriteLine(result);

                Console.Write("Continue? (Y/N)");
                continueLoop = Convert.ToChar(Console.ReadLine());
                Console.Clear();
            }
        }
    }
}
