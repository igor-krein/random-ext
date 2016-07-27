using RandomExtensions;
using System;
using System.Collections.Generic;

namespace RandomExtensionsExample
{
    public class PersonGenerator
    {
        private static Random _random = new Random();
        private static string[] _maleNames = { "John", "Rex", "Andrew", "Jonathan", "Stephen", "Frederick", "Louis", "Matthew", "Rupert", "Brad", "Roy", "Hugh", "Thomas" };
        private static string[] _femaleNames = { "Mary", "Anne", "Helen", "Bonnie", "Catherine", "Eva", "Jane", "Sandy", "Violet", "Barbara", "Julia" };
        private static string[] _lastNames = { "Johnson", "King", "Verne", "Hawk", "Sterling", "Stout", "Webster", "Knight", "Aston", "Anderson", "Fred", "Mann", "Coltraine", "Truman", "Quark", "Twain", "Simmons", "Gunn", "Sand", "Hightower", "Whitaker", "Ginger", "Hipster", "Bradshow", "Clay" };

        public static List<Person> GeneratePersons(int personCount)
        {
            List<Person> persons = new List<Person>();
            DateTime birthFrom = new DateTime(1800, 1, 1);
            DateTime birthTo = DateTime.Now.AddYears(-25);

            for (int i = 0; i < personCount; i++)
            {
                // 1/2 males, 1/2 females
                Person.PersonSex sex = _random.ThrowDiceToHit(2, 2) ? Person.PersonSex.Male : Person.PersonSex.Female;
                IList<string> firstNames = (sex == Person.PersonSex.Male) ? _maleNames : _femaleNames;

                // first name - random item from _maleNames or _femaleNames array
                string firstName = _random.NextItem(firstNames);

                // last name - random item from _lastNames array
                string lastName = _random.NextItem(_lastNames);

                string middleName = null, maidenName = null;

                // 1/3 persons to have a middle name
                if (_random.HitBullsEye(3))
                {
                    // in 3 (8..10) of 10 cases middle name is just a letter (like Jerome K. Jerome)
                    middleName = _random.ThrowDiceToHit(10, 8)
                        ? $"{(char)('A' + _random.Next(0, 26))}."
                        : _random.NextItem(firstNames);     // Note: middle name here could be equal to first name for simplicity
                }

                // Females could have a maiden name...
                if (sex == Person.PersonSex.Female)
                {
                    // ... in 7 (4..10) of 10 cases
                    // Note: maiden name here could be equal to last name for simplicity
                    maidenName = _random.NextItemOrDefault(_lastNames, 10, 4);
                }

                // Date of birth is a date between 1/1/1800 and a day that was 25 years ago
                DateTime birthDate = _random.NextDate(birthFrom, birthTo);
                DateTime? deathDate = null;

                // The person is dead already if:
                // - he/she was born more than 100 years ago
                // - or in 1/4 of the rest cases
                if ((DateTime.Now.Year - birthDate.Year > 100) || _random.HitBullsEye(4))
                {
                    // Date of death is a date between:
                    // - date of birth + 25 years
                    // - and date of birth + 100 years or today (the lesser of the two)
                    DateTime deathFrom = birthDate.AddYears(25);
                    DateTime deathTo = birthDate.AddYears(100);
                    if (deathTo > DateTime.Now) deathTo = DateTime.Now;
                    deathDate = _random.NextDate(deathFrom, deathTo);
                }

                Person person = new Person
                {
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    MaidenName = maidenName,
                    Sex = sex,
                    BirthDate = birthDate,
                    DeathDate = deathDate
                };

                persons.Add(person);
            }
            return persons;
        }

    }
}
