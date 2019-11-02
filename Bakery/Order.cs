using System;
using System.Collections.Generic;

namespace BakeryLibrary
{
    public class Order
    {
        public List<ICake> CakeOrder { get; private set; }
        public DateTime OrderCompleteTime { get; private set; }
        public Worker WorkerResponsibleForOrder { get; private set; }
        public Customer CustomerWhoOrdered { get; private set; }
        public int OrderCost { get; set; }
        public Order(DateTime orderStartTime, Worker workerResponsibleForOrder, Customer customerWhoOrdered) {
            this.CakeOrder = GenerateOrder();
            this.WorkerResponsibleForOrder = workerResponsibleForOrder;
            this.CustomerWhoOrdered = customerWhoOrdered;
            OrderCompleteTime = CalcOrderTime(orderStartTime);
            OrderCost = CalcOrderCost();
        }

        private int CalcOrderCost()
        {
            int totalCost = 0;
            foreach (ICake c in CakeOrder) {
                totalCost += c.Cost;
            } 
            return totalCost;
        }

        private DateTime CalcOrderTime(DateTime orderStartTime)
        {
            DateTime completeTime=orderStartTime;
            foreach (ICake c in CakeOrder) {
                completeTime = completeTime.AddMinutes(c.BakeTime/WorkerResponsibleForOrder.BakeEfficiency);
            }
            return completeTime;
        }

        private List<ICake> GenerateOrder()
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
