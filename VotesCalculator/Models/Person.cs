using System;
using System.Collections.Generic;
using System.Text;

namespace VotesCalculator
{
    class Person
    {
        private string Name { get; set; }
        private string LastName { get; set; }

        public Person(string name, string lastname)
        {
            Name = name;
            LastName = lastname;
        }
    }
}
