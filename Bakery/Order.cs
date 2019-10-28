using System.Collections.Generic;

namespace Bakery
{
    public class Order
    {
        public List<Cake> cakeOrder = new List<Cake>();

        public int CalcTotalCost(List<Cake> cakeList) {
            int returnValue=0;
            foreach (Cake c in cakeList) {
                returnValue = returnValue + c.Cost;
            }

            return returnValue;
        }

        public int CalcTotalBakeTime(List<Cake> cakeList)
        {
            int returnValue = 0;
            foreach (Cake c in cakeList)
            {
                returnValue = returnValue + c.BakeTime;
            }

            return returnValue;
        }


    }
}
