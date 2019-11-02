using System;
using System.Collections.Generic;

namespace BakeryLibrary
{
    public class Baker : Worker
    {
        public Baker(DateTime hiredDate)
        {
            NameGenerator name = new NameGenerator();
            FirstName = name.GenerateFirstName();
            LastName = name.GenerateLastName();
            BakeEfficiency = 2;
            IsWorking = false;
            WorkTitle = "Baker";
            HiredDate = hiredDate;
            Salary = CalculateSalary(BakeEfficiency);
        }

        //for promoting apprentice to real baker
        public Baker(string firstName, string lastName, DateTime hiredDate, bool isWorking)
        {
            FirstName = firstName;
            LastName = lastName;
            BakeEfficiency = 2;
            IsWorking = isWorking;
            WorkTitle = "Baker";
            HiredDate = hiredDate;
            Salary = CalculateSalary(BakeEfficiency);
        }

        public override int CalculateSalary(int bakeEfficiency)
        {
            return bakeEfficiency * 500;

        }

    }
}
