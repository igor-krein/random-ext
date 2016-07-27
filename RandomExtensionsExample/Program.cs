using System;
using System.Collections.Generic;

namespace RandomExtensionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> personList = PersonGenerator.GeneratePersons(200);

            foreach (Person person in personList)
                Console.WriteLine(person);
        }
    }
}
