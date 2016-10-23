using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI
{
    class Person
    {
        public string Name { get; set; }
        private double Height { get; set; }
        private double Weight { get; set; }

        public Person(string name, double height, double weight)
        {
            this.Name = name;
            this.Height = height;
            this.Weight = weight;
        }

        //calculate person's BMI
        public double CalcBMI()
        {
            return (703 * this.Weight) / (this.Height * this.Height);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Create list of people
            List<Person> People = new List<Person>();
            People.Add(new Person("Brian", 70, 220));
            People.Add(new Person("Alex", 74, 250));
            People.Add(new Person("Rita", 66, 98));
            People.Add(new Person("Erika", 62, 100));
            People.Add(new Person("Mike", 71, 140));
            People.Add(new Person("Joanie", 62, 120));
            People.Add(new Person("Marcus", 64, 135));

            Console.WriteLine("*****BMI CALCULATOR*****");
            Console.WriteLine();

            //calculate overweight people and store them
            IEnumerable<Person> overweight =
                from person in People
                where person.CalcBMI() > 25
                select person;

            Console.WriteLine("Overweight (greater than 25 BMI): ");
            
            //print list of overweight people
            foreach(Person person in overweight)
            {
                Console.WriteLine(person.Name + ": " + Math.Round(person.CalcBMI(), 2));
            }

            Console.WriteLine();

            //calculate idealweight people and store them
            IEnumerable<Person> idealweight =
                from person in People
                where person.CalcBMI() > 20 && person.CalcBMI() < 25
                select person;

            Console.WriteLine("Ideal Weight (between 20 and 25 BMI): ");


            //print list of idealweight people
            foreach (Person person in idealweight)
            {
                Console.WriteLine(person.Name + ": " + Math.Round(person.CalcBMI(), 2));
            }

            //calculate underweight people and store them
            IEnumerable<Person> underweight =
                from person in People
                where person.CalcBMI() < 20
                select person;

            Console.WriteLine();
            Console.WriteLine("Underweight (less than 20 BMI: ");

            //print list of underweight people
            foreach(Person person in underweight)
            {
                Console.WriteLine(person.Name + ": " + Math.Round(person.CalcBMI(), 2));
            }

            Console.ReadLine();
        }
    }
}
