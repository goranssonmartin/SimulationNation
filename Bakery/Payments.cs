using System;
using System.Collections.Generic;

namespace BakeryLibrary
{
    public class Payments : IPaymentHandler
    {
        public int AcceptPayment(int currentMoney, int income)
        {
            return currentMoney + income;
        }

        public int HandlePantryPayment(int currentMoney, int moneyToPay)
        {
            return currentMoney-moneyToPay;
        }

        public int PayBakers(int currentMoney, List<Worker> listOfBakers)
        {
            int totalPayments = 0;
            foreach (Worker worker in listOfBakers)
            {
                totalPayments = totalPayments + worker.Salary;
            }
            return currentMoney - totalPayments;
        }

        public int PayRent(int currentMoney)
        {
            return currentMoney - 1000;
        }


    }
}
