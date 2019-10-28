using System;
using System.Collections.Generic;

namespace Bakery
{
    public class Bakery
    {

        public int currentMoney;
        List<Worker> listOfBakers = new List<Worker>();

        List<Customer> listOfCustomers = new List<Customer>();
        Dictionary<string, int> pantry = new Dictionary<string, int>();
        public Bakery()
        {
            currentMoney = 5000;
            pantry.Add("Sugar", 100);
            pantry.Add("Egg", 100);
            pantry.Add("Butter", 100);
        }

        public Dictionary<string, int> ReturnPantry() {
            return pantry;
        }

        public List<Worker> ReturnBakers()
        {
            return listOfBakers;
        }

        public List<Customer> ReturnCustomers()
        {
            return listOfCustomers;
        }

        public void HireBaker() {
            listOfBakers.Add(new Baker());
        }

        public void HireApprentice()
        {
            listOfBakers.Add(new BakerApprentice());
        }

        public void GetNewCustomer()
        {
            listOfCustomers.Add(new Customer());
        }

        public void FillPantry(string ingredient)
        {
            Sugar sugar = new Sugar();
            Egg egg = new Egg();
            Butter butter = new Butter();
            Payments payments = new Payments();

            if (ingredient == "Sugar")
            {
                int sugarToBuyCost = (100 - pantry["Sugar"]) * sugar.Cost;
                currentMoney = payments.HandlePantryPayment(currentMoney, sugarToBuyCost);
                pantry["Sugar"] = 100;
            }
            else if (ingredient == "Egg")
            {
                int eggToBuyCost = (100 - pantry["Egg"]) * egg.Cost;
                currentMoney = payments.HandlePantryPayment(currentMoney, eggToBuyCost);
                pantry["Egg"] = 100;
            }
            else if (ingredient == "Butter")
            {
                int butterToBuyCost = (100 - pantry["Butter"]) * butter.Cost;
                currentMoney = payments.HandlePantryPayment(currentMoney, butterToBuyCost);
                pantry["Butter"] = 100;
            }
        }

        public void UseUpIngredient(string ingredient, int quantity)
        {
            if (pantry[ingredient] > quantity)
            {
                pantry[ingredient] = pantry[ingredient] - quantity;
            }
            else if (pantry[ingredient] <= quantity)
            {
                FillPantry(ingredient);
                UseUpIngredient(ingredient, quantity);
            }
        }

        
    }


}
