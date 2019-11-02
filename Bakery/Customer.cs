using System;

namespace BakeryLibrary
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Customer()
        {
            NameGenerator name = new NameGenerator();
            FirstName = name.GenerateFirstName();
            LastName = name.GenerateLastName();
        }
    }
}
