using Bakery;
using ConsoleSimulationEngine2000;
using System;
using System.Collections.Generic;
namespace SimulationNation
{
    public class MySimulation : Simulation
    {
        private RollingDisplay log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay clockDisplay = new BorderedDisplay(0, 11, 20, 3) { };
        private BorderedDisplay pantryDisplay = new BorderedDisplay(0, 14, 40, 3) { };
        private BorderedDisplay commandDisplay = new BorderedDisplay(-40, 11, 40, 6) { };
        private BorderedDisplay moneyDisplay = new BorderedDisplay(20, 11, 20, 3) { };
        private BorderedDisplay workingBakers = new BorderedDisplay(0, 17, 30, 10) { };

        public Bakery.Bakery bakery = new Bakery.Bakery();
        private ConsoleGUI gui;
        private TextInput input;
        private DateTime actualTime;
        private DateTime currentDay;
        Payments payments = new Payments();

        public MySimulation(ConsoleGUI gui, TextInput input)
        {

            actualTime = DateTime.Now;
            currentDay = DateTime.Now;
            this.gui = gui;
            this.input = input;
        }

        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {
            log,
            pantryDisplay,
            clockDisplay,
            commandDisplay,
            moneyDisplay,
            workingBakers,
            input.CreateDisplay(0, -3, -1)
        };
        public override void Update(int deltaTime)
        {
            if (actualTime.Day>currentDay.Day) {
                bakery.currentMoney=(payments.PayRent(bakery.currentMoney));
                bakery.currentMoney = (payments.PayBakers(bakery.currentMoney, bakery.ReturnBakers()));
                log.Log("Rent Payed");
                currentDay = actualTime;
            }

            clockDisplay.Value = actualTime.ToString("HH:mm");
            actualTime = actualTime.AddMinutes(3);
            
            commandDisplay.Lines = new string[] { "COMMANDS", "1. Create Order", "2. Hire Baker", "3. Hire Baker Apprentice" };
            workingBakers.Lines = WorkingBakers();
            moneyDisplay.Value = bakery.currentMoney + " Schmeckles";
            pantryDisplay.Value = ("Sugar:" + bakery.ReturnPantry()["Sugar"] + "  Egg:" + bakery.ReturnPantry()["Egg"] + "  Butter:" + bakery.ReturnPantry()["Butter"]);
            while (bakery.ReturnCustomers().Count <3) {
                bakery.GetNewCustomer();
            }
            while (input.HasInput)
            {
                string commandInput = input.Consume();
                ExecuteCommand(commandInput);
            }

        }

        public void ExecuteCommand(string commandInput)
        {
            if (commandInput == "1")
            {
                Customer c = new Customer();
                Order order = new Order();
                List<ICake> newCakeOrder = order.GenerateOrder();
                log.Log(c.FirstName + " " + c.LastName + " entered the bakery");
            }

            else if (commandInput == "2" && bakery.ReturnBakers().Count < 9)
            {
                bakery.HireBaker();
                log.Log(bakery.ReturnBakers()[bakery.ReturnBakers().Count - 1].FirstName + " " + bakery.ReturnBakers()[bakery.ReturnBakers().Count - 1].LastName + " hired!");
            }

            else if (commandInput == "3" && bakery.ReturnBakers().Count < 9) {
                bakery.HireApprentice();
                log.Log(bakery.ReturnBakers()[bakery.ReturnBakers().Count - 1].FirstName + " " + bakery.ReturnBakers()[bakery.ReturnBakers().Count - 1].LastName + " hired!");
            }


        }

        public string[] WorkingBakers()
        {
            string[] arrayOfBakers = new string[bakery.ReturnBakers().Count];
            for (int i = 0; i < bakery.ReturnBakers().Count; i++)
            {
                arrayOfBakers[i] = i+1 +". " + bakery.ReturnBakers()[i].FirstName + " " + bakery.ReturnBakers()[i].LastName;
            }
            return arrayOfBakers;
        }
    }
}
