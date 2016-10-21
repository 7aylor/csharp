using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public static class StringExtension
    {
        public static int WordCount(this string s)
        {
            string[] words = s.Split(' ');
            return words.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string a = "Hello, how are you?";
            Console.WriteLine(a.WordCount());
            Console.ReadLine();   
        }
    }
}
