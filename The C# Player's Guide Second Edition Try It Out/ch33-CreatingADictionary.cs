using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingADictionary
{
    public class Dictionary
    {
        private List<string> words;
        private List<string> definitions;

        public Dictionary()
        {
            words = new List<string>();
            definitions = new List<string>();
        }

        public string this[string word]
        {
            get
            {
                string result = LookUpWord(word);
                if(result == null)
                {
                    throw new KeyNotFoundException(word);
                }
                return result;
            }
            set
            {
                AddDefinition(word, value);
            }
        }

        public string LookUpWord(string word)
        {
            for(int i = 0; i < words.Count; i++)
            {
                if(words[i] == word)
                {
                    return definitions[i];
                }
            }

            return null;
        }

        public void AddDefinition(string word, string definition)
        {
            for(int i = 0; i < words.Count; i++)
            {
                if(words[i] == word)
                {
                    definitions[i] = definition;
                    return;
                }
            }

            words.Add(word);
            definitions.Add(definition);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary dict = new Dictionary();
            dict.AddDefinition("test", "123");
            dict["one"] = "My favorite";
            dict["book"] = "The Hobbit";
            dict["movie"] = "Fight Club";

            Console.WriteLine(dict["one"]);
            Console.WriteLine(dict["book"]);
            Console.ReadKey();
        }
    }
}
