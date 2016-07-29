using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomExtensionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> personList = PersonGenerator.GeneratePersons(200);

            foreach (Person person in personList)
                Console.WriteLine(person);

            var totalCount = personList.Count();
            Console.WriteLine($"Total number of persons: {totalCount}");

            var men = personList.Where(p => p.Sex == Person.PersonSex.Male);
            var menCount = men.Count();
            Console.WriteLine($"Number of men: {menCount}");

            var women = personList.Where(p => p.Sex == Person.PersonSex.Female);
            var womenCount = women.Count();
            Console.WriteLine($"Number of women: {womenCount}");

            var personsWithMiddleNameCount = personList.Where(p => p.MiddleName != null).Count();
            Console.WriteLine($"Number of persons with middle names: {personsWithMiddleNameCount}");

            var womenWithMaidenNameCount = women.Where(w => w.MaidenName != null).Count();
            Console.WriteLine($"Number of women with maiden names: {womenWithMaidenNameCount}");

            var deadPersonsCount = personList.Where(p => p.DeathDate != null).Count();
            Console.WriteLine($"Number of dead persons: {deadPersonsCount}");

        }
    }
}
