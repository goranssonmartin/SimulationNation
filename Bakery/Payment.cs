using System;
using System.Collections.Generic;

namespace BakeryLibrary
{
    public class Payment : IPaymentHandler
    {
        public int AcceptPayment(int currentMoney, int income)
        {
            return currentMoney + income;
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
