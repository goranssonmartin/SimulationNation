using System;
using System.Collections.Generic;

namespace BakeryLibrary
{
    public class Bakery
    {

        public int currentMoney;
        public List<Customer> listOfCustomers { get; private set; }
        public List<Worker> listOfBakers { get; private set; }
        public List<Order> listOfOrders { get; private set; }
        public Dictionary<string, int> pantry { get; private set; }
        public Bakery()
        {
            currentMoney = 5000;
            listOfCustomers = new List<Customer>();
            listOfBakers = new List<Worker>();
            listOfOrders = new List<Order>();
            pantry = new Dictionary<string, int>();
            pantry.Add("Sugar", 100);
            pantry.Add("Egg", 100);
            pantry.Add("Butter", 100);
        }



        public void HireBaker(DateTime actualTime)
        {
            listOfBakers.Add(new Baker(actualTime));
        }

        public void HireApprentice(DateTime actualTime)
        {
            listOfBakers.Add(new BakerApprentice(actualTime));
        }

        public string UpgradeApprentice(DateTime actualTime)
        {
            string returnString = "";
            for (int i = 0; i < listOfBakers.Count; i++)
            {
                DateTime test =listOfBakers[i].HiredDate.AddDays(7);
                if (listOfBakers[i].WorkTitle == "Baker Apprentice" && test.Day < actualTime.Day)
                {
                    listOfBakers[i] = new Baker(listOfBakers[i].Name, listOfBakers[i].HiredDate, listOfBakers[i].IsWorking);
                    returnString=listOfBakers[i].Name + " is now a fully trained baker";
                }
            }
            return returnString;
        }
        public string GenerateNewOrder(DateTime actualTime)
        {
            string returnString = "";
            Worker worker = AssignWorker();
            if (listOfOrders.Count < listOfBakers.Count)
            {
                Customer c = new Customer();
                listOfCustomers.Add(c);
                Order order = new Order(actualTime, worker, c);
                returnString= c.Name + " has entered the bakery and made an order!";
                listOfOrders.Add(order);
            }
            return returnString;
        }

        private Worker AssignWorker()
        {
            Worker worker = null;
            foreach (Worker w in listOfBakers)
            {
                if (w.IsWorking == false)
                {
                    worker = w;
                    return worker;
                }
            }
            return worker;
        }

        public string CheckIfOrderIsComplete(DateTime actualTime, Payments payments)
        {
            string returnString = "";
            for (int i = listOfOrders.Count - 1; i >= 0; i--)
            {
                if (listOfOrders[i].OrderCompleteTime < actualTime)
                {
                    UseUpIngredient(listOfOrders[i]);
                    returnString=(listOfOrders[i].CustomerWhoOrdered.Name + "s " + "order complete, " + listOfOrders[i].OrderCost + " schmeckles added to cash register");
                    currentMoney = payments.AcceptPayment(currentMoney, listOfOrders[i].OrderCost);
                    listOfOrders.RemoveAt(i);
                }
            }
            return returnString;
        }

        public void UseUpIngredient(Order order)
        {
            foreach (var cake in order.CakeOrder) {
                foreach (var ingredient in cake.CakeIngredients)
                {
                    if (pantry[ingredient.Name] > 1)
                    {
                        pantry[ingredient.Name] -= 1;
                    }

                    else {
                        FillPantry(ingredient.Name, ingredient.Cost);
                    }
                }
            }
        }
        public void FillPantry(string ingredient, int cost)
        {
            pantry[ingredient] = 100;
            currentMoney = currentMoney - cost * 100;
        }

    }

}
