using System;

namespace Bakery
{
    public class NameGenerator
    {
        private string[] firstNames = { "Lara", "Jeremy", "Mark", "Tony", "Jon","Bruce","Alan","Ellen","Barbara","Emily" };
        private string[] lastNames = { "Croft", "Usbourne", "Corrigan", "Stark", "Snow","Wayne","Wake","Ripley","Gordon", "Kaldwin" };
        public string GenerateFirstName()
        {
            Random rnd = new Random();
            int indexOfFirstName = rnd.Next(0, firstNames.Length);
            return firstNames[indexOfFirstName];
        }

        public string GenerateLastName()
        {
            Random rnd = new Random();
            int indexOfLastName = rnd.Next(0, lastNames.Length);
            return lastNames[indexOfLastName];
        }
    }
}
