using System;

namespace BakeryLibrary
{
    public class Customer
    {
        public string Name { get; set; }
        public Customer()
        {
            NameGenerator name = new NameGenerator();
            Name = name.GenerateFirstName() + " " + name.GenerateLastName();
        }
    }
}
