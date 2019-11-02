using System.Collections.Generic;

namespace BakeryLibrary
{
    public interface IPaymentHandler
    {
        int AcceptPayment(int currentMoney, int income);
        int HandlePantryPayment(int currentMoney, int moneyToPay);
        int PayBakers(int currentMoney, List<Worker> listOfBakers);

        int PayRent(int currentMoney);
    }
}
