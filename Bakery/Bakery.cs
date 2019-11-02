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
