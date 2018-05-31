using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    [Serializable]
    public class Person
    {
        ~Person()
        {
            Console.WriteLine("Вызов диструктора");
            for (int i = 0; i < 10000000; i++)
            {
                Console.WriteLine(i);
            }
        }

        public string Name { get; set; }
        public int Year { get; set; }

        public Person()
        {

        }
        public Person(string Name, int Year)
        {
            this.Name = Name;
            this.Year = Year;  
        }

        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", 
                this.Name, this.Year);
        }

        public int GetAge(int currentYear)
        {
            return currentYear - this.Year;
        }

    }

    public class Human : Person
    {
        public Human(string Name, int Year) : base(Name, Year)
        {
        }
    }
}
