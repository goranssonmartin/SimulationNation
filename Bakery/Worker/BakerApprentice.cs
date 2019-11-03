using System;

namespace BakeryLibrary
{
    public class BakerApprentice : Worker
    {
        public BakerApprentice(DateTime hiredDate)
        {
            NameGenerator name = new NameGenerator();
            Name = name.GenerateFirstName() + " " + name.GenerateLastName();
            BakeEfficiency = 1;
            IsWorking = false;
            WorkTitle = "Baker Apprentice";
            HiredDate = hiredDate;
            Salary = CalculateSalary(BakeEfficiency);
        }

        public override int CalculateSalary(int bakeEfficiency)
        {
            return bakeEfficiency * 300;
        }
    }
}
