using System;

namespace Bakery
{
    public class Payments : IPaymentHandler
    {
        public void AcceptPayment(int currentMoney, int newMoney)
        {
            currentMoney = currentMoney - newMoney;
        }

        public void PayBakers()
        {
            foreach
        }
    }
}
