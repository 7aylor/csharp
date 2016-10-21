using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingYourOwnGenericListClass
{
    class PracticeList<T>
    {
        private T[] items;

        public PracticeList()
        {
            items = new T[0];
        }

        public T GetItem(int index)
        {
            return items[index];
        }

        public void Add(T newItem)
        {
            T[] newItems = new T[items.Length + 1];

            for (int i = 0; i < items.Length; i++)
            {
                newItems[i] = items[i];
            }

            newItems[newItems.Length - 1] = newItem;
            items = newItems;

        }

        public void Pop()
        {
            T[] newItems = new T[items.Length - 1];

            for (int i = 0; i < newItems.Length; i++)
            {
                newItems[i] = items[i];
            }

            items = newItems;
        }

        public void PrintList()
        {
            for(int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PracticeList<int> list = new PracticeList<int>();

            list.Add(4);
            list.Add(5);
            list.Add(7);
            list.Pop();

            list.PrintList();
            Console.ReadKey();

        }
    }
}
