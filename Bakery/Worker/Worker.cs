﻿using System;

namespace BakeryLibrary
{
    public abstract class Worker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsWorking { get; set; }
        public int BakeEfficiency { get; set; }
        public DateTime HiredDate { get; set; }

        public string WorkTitle { get; set; }
        public int Salary { get; set; }
        public abstract int CalculateSalary(int bakeEfficiency);

    }
}
