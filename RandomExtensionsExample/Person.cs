using System;

namespace RandomExtensionsExample
{
    public class Person
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        private string middleNamePart { get { return (MiddleName?.Length ?? 0) > 0 ? $" {MiddleName}" : ""; } }

        public string LastName { get; set; }

        public string MaidenName { get; set; }
        private string maidenNamePart { get { return (MaidenName?.Length ?? 0) > 0 ? $" ({MaidenName})" : ""; } }

        public string FullName
        {
            get
            {
                return $"{FirstName}{middleNamePart} {LastName}{maidenNamePart}";
            }
        }

        public enum PersonSex { Male, Female }
        public PersonSex Sex;

        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public override string ToString()
        {
            return $"{FullName} [{Sex}] ({BirthDate.Date.ToShortDateString()}--{DeathDate?.Date.ToShortDateString()})";
        }

    }
}
