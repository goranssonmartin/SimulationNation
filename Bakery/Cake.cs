using System;

namespace Bakery
{
    public class Cake
    {
        string orderNo;

    }

    public interface IPaymentHandler {
        void AcceptPayment();
        void PayBakers();
    }

    public abstract class Human
    {
        string firstName;
        string lastName;

        public abstract void ProcessOrder(Order order);
    }

    public class Baker : Human
    {
        char quality;

        public override void ProcessOrder(Order Order)
        {
            throw new NotImplementedException();
        }
    }

    public class Customer : Human
    {

        public override void ProcessOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }


    public class Order
    {

    }

    public class Ingredient
    {

    }

    public class Payments : IPaymentHandler
    {
        public void AcceptPayment()
        {
            throw new NotImplementedException();
        }

        public void PayBakers()
        {
            throw new NotImplementedException();
        }
    }
}
