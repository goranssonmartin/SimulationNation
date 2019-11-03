using System;
using System.Collections.Generic;

namespace BakeryLibrary
{
    public class Baker : Worker
    {
        public Baker(DateTime hiredDate)
        {
            NameGenerator name = new NameGenerator();
            Name = name.GenerateFirstName() + " " + name.GenerateLastName();
            BakeEfficiency = 2;
            IsWorking = false;
            WorkTitle = "Baker";
            HiredDate = hiredDate;
            Salary = CalculateSalary(BakeEfficiency);
        }

        //for promoting apprentice to real baker
        public Baker(string name, DateTime hiredDate, bool isWorking)
        {
            Name = name;
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
