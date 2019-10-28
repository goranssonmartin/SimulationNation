using System;
using System.Collections.Generic;

namespace Bakery
{
    public class Baker : Worker
    {
        public override int Quality { get { return 2; } set { } }
        
        public int BakeEfficiency { get; set; }

        public Baker() {
            NameGenerator name = new NameGenerator();
            FirstName = name.GenerateFirstName();
            LastName = name.GenerateLastName();
            Quality = 2;
            BakeEfficiency = 1;
        }

        public override void ProcessOrder()
        {
            throw new NotImplementedException();
        }

        public int TimeToBake(List<ICake> order) {
            int bakeTime = 0;
            foreach (ICake c in order) {
                bakeTime = bakeTime + c.BakeTime;
            }
            return (bakeTime / BakeEfficiency);
        }

        public void TrainBaker() {
            Quality++;
        }
    }
}
