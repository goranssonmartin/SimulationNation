using System.Collections.Generic;

namespace BakeryLibrary
{
    public interface IPaymentHandler
    {
        int AcceptPayment(int currentMoney, int income);
        int PayBakers(int currentMoney, List<Worker> listOfBakers);
        int PayRent(int currentMoney);
    }
}
