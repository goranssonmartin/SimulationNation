using System;
using System.Collections.Generic;

namespace Bakery
{
    public class Order
    {
        public List<ICake> cakeOrder = new List<ICake>();

        public int CalcTotalCost(List<ICake> cakeList)
        {
            int returnValue = 0;
            foreach (ICake c in cakeList)
            {
                returnValue = returnValue + c.Cost;
            }

            return returnValue;
        }

        public List<ICake> GenerateOrder()
        {
            Random rnd = new Random();
            int whatToOrder = rnd.Next(1, 4);

            Random numberOfCakes = new Random();

            if (whatToOrder == 1)
            {
                List<ICake> smallCakeOrder = new List<ICake>();
                for (int i = 0; i < numberOfCakes.Next(1, 7); i++)
                {
                    smallCakeOrder.Add(new SmallCake());
                }
                return smallCakeOrder;
            }

            else if (whatToOrder == 2)
            {
                List<ICake> mediumCakeOrder = new List<ICake>();
                for (int i = 0; i < numberOfCakes.Next(1, 7); i++)
                {
                    mediumCakeOrder.Add(new MediumCake());
                }
                return mediumCakeOrder;
            }

            else
            {
                List<ICake> largeCakeOrder = new List<ICake>();
                for (int i = 0; i < numberOfCakes.Next(1, 7); i++)
                {
                    largeCakeOrder.Add(new LargeCake());
                }
                return largeCakeOrder;
            }

        }

    }
}
