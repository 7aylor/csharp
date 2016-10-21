using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = GenerateNumbers();
            PrintNumbers(numbers);
            Reverse(numbers);
            PrintNumbers(numbers);
            Console.ReadKey();
        }
        static int[] GenerateNumbers(int count=10)
        {
            int[] nums = new int[count];
            Random random = new Random();
            for(int i = 0; i < count; i++)
            {
                nums[i] = random.Next() % 100;
            }
            return nums;
        }
        static void Reverse(int[] numbers)
        {
            for(int i = 0; i < (numbers.Length / 2); i++)
            {
                int temp = numbers[i];
                numbers[i] = numbers[numbers.Length - i- 1];
                numbers[numbers.Length - i - 1] = temp;
            }
        }
        static void PrintNumbers(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
