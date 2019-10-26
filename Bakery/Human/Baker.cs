using System;

namespace Bakery
{
    public class Baker : Human
    {
        public char Quality { get; private set; }

        public override void ProcessOrder(Order Order)
        {
            throw new NotImplementedException();
        }
    }
}
