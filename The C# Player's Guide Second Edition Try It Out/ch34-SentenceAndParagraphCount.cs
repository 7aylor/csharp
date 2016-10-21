using System;
using System.IO;
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
            return s.Split(' ').Length;
        }

        public static int SentenceCount(this string s)
        {
            return s.Split('.').Length;
        }

        public static int ParagraphCount(this string s)
        {
            return s.Split('\n').Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string file = File.ReadAllText("C:/Users/tbuch/Desktop/test.txt");
            Console.WriteLine("Words: {0}", file.WordCount());
            Console.WriteLine("Sentences: {0}", file.SentenceCount());
            Console.WriteLine("Paragraphs: {0}", file.ParagraphCount());

            Console.ReadLine();   
        }
    }
}
