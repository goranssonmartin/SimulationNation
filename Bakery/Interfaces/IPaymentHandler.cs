namespace Bakery
{
    public interface IPaymentHandler
    {
        void AcceptPayment(int currentMoney, int newMoney);
        void PayBakers(int currentMoney);
    }
}
