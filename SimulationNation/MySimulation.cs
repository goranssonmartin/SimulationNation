using BakeryLibrary;
using ConsoleSimulationEngine2000;
using System;
using System.Collections.Generic;
namespace SimulationNation
{
    public class MySimulation : Simulation
    {
        private RollingDisplay newOrdersLog = new RollingDisplay(0, 0, 75, 12);
        private RollingDisplay completedOrdersLog = new RollingDisplay(74, 0, 76, 12);
        private BorderedDisplay pantryDisplay = new BorderedDisplay(0, 14, 42, 3) { };
        private BorderedDisplay commandDisplay = new BorderedDisplay(-40, 12, 40, 7) { };
        private BorderedDisplay moneyDisplay = new BorderedDisplay(20, 12, 22, 3) { };
        private BorderedDisplay clockDisplay = new BorderedDisplay(0, 12, 22, 3) { };
        private BorderedDisplay workingBakers = new BorderedDisplay(0, 17, 45, 10) { };
        private RollingDisplay logForBakeryRelatedUpdates = new RollingDisplay(44, 17, 55, 10) { };

        private Bakery bakery = new Bakery();
        private Payments payments = new Payments();
        private bool generateCustomers = false;
        private ConsoleGUI gui;
        private TextInput input;
        private DateTime actualTime;
        private DateTime currentDay;
        private int simulationDay;

        public MySimulation(ConsoleGUI gui, TextInput input)
        {
            actualTime = DateTime.Now;
            currentDay = actualTime;
            simulationDay = 1;
            newOrdersLog.Log("Welcome to this made up bakery!");
            newOrdersLog.Log("Type a number available in the list of commands to execute a command");
            this.gui = gui;
            this.input = input;
        }

        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {
            newOrdersLog,
            pantryDisplay,
            clockDisplay,
            commandDisplay,
            moneyDisplay,
            workingBakers,
            logForBakeryRelatedUpdates,
            completedOrdersLog,
            input.CreateDisplay(0, -3, -1)
        };
        public override void Update(int deltaTime)
        {

            clockDisplay.Value = "Day: " + simulationDay + "  " + actualTime.ToString("HH:mm");
            commandDisplay.Lines = new string[] { "COMMANDS", "1. Start", "2. Hire Baker", "3. Hire Baker Apprentice", "4. Stop" };
            workingBakers.Lines = WorkingBakers();
            moneyDisplay.Value = bakery.currentMoney + " Schmeckles";
            pantryDisplay.Value = ("Sugar: " + bakery.pantry["Sugar"] + "  Egg: " + bakery.pantry["Egg"] + "  Butter: " + bakery.pantry["Butter"]);


            if (generateCustomers)
            {
                actualTime = actualTime.AddMinutes(30);
                GenerateNewOrder();
                CheckIfOrderIsComplete();
                UpgradeApprentice();
            }


            //making sure that this runs even if month or year changes
            if (actualTime.Day>currentDay.Day ||actualTime.Month>currentDay.Month||actualTime.Year>currentDay.Year)
            {
                bakery.currentMoney = (payments.PayRent(bakery.currentMoney));
                bakery.currentMoney = (payments.PayBakers(bakery.currentMoney, bakery.listOfBakers));
                logForBakeryRelatedUpdates.Log("Day " + simulationDay + ": " + "Rent paid!");
                simulationDay++;
                currentDay = actualTime;
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
                newOrdersLog.Log("Simulation started");
                generateCustomers = true;
            }

            else if (commandInput == "2")
            {
                if (bakery.listOfBakers.Count < 9)
                {
                    bakery.HireBaker(actualTime);
                    HiredWriter();
                }
                else
                {
                    logForBakeryRelatedUpdates.Log("Maximum number of bakers reached");
                }
            }

            else if (commandInput == "3")
            {
                if (bakery.listOfBakers.Count < 9)
                {
                    bakery.HireApprentice(actualTime);
                    HiredWriter();
                }
                else
                {
                    logForBakeryRelatedUpdates.Log("Maximum number of bakers reached");
                }
            }

            else if (commandInput == "4")
            {
                newOrdersLog.Log("Simulation stopped");
                generateCustomers = false;
            }
        }

        private void UpgradeApprentice()
        {
            for (int i = 0; i < bakery.listOfBakers.Count; i++) 
            {
                DateTime test = bakery.listOfBakers[i].HiredDate.AddDays(7);
                if (bakery.listOfBakers[i].WorkTitle == "Baker Apprentice" && test.Day < actualTime.Day)
                {
                    bakery.listOfBakers[i] = new Baker(bakery.listOfBakers[i].FirstName, bakery.listOfBakers[i].LastName, bakery.listOfBakers[i].HiredDate, bakery.listOfBakers[i].IsWorking);
                    logForBakeryRelatedUpdates.Log(bakery.listOfBakers[i].FirstName + " " + bakery.listOfBakers[i].LastName + " is now a fully trained baker");
                    workingBakers.Lines = WorkingBakers();
                }
            }
        }

        private void CheckIfOrderIsComplete()
        {
            for (int i = bakery.listOfOrders.Count - 1; i >= 0; i--)
            {
                if (bakery.listOfOrders[i].OrderCompleteTime < actualTime)
                {
                    bakery.UseUpIngredient(bakery.listOfOrders[i]);
                    completedOrdersLog.Log(bakery.listOfOrders[i].CustomerWhoOrdered.FirstName+" "+ bakery.listOfOrders[i].CustomerWhoOrdered.LastName+"s " +"order complete, " + bakery.listOfOrders[i].OrderCost + " schmeckles added to cash register");
                    bakery.currentMoney = payments.AcceptPayment(bakery.currentMoney, bakery.listOfOrders[i].OrderCost);
                    bakery.listOfOrders.RemoveAt(i);
                }
            }
        }

        private void GenerateNewOrder()
        {
            Worker worker = AssignWorker();
            if (bakery.listOfOrders.Count < bakery.listOfBakers.Count)
            {
                Customer c = new Customer();
                bakery.listOfCustomers.Add(c);
                Order order = new Order(actualTime, worker, c);
                newOrdersLog.Log(c.FirstName + " " + c.LastName + " has entered the bakery and made an order!");
                bakery.listOfOrders.Add(order);
            }
        }

        private Worker AssignWorker()
        {
            Worker worker = null;
            foreach (Worker w in bakery.listOfBakers)
            {
                if (w.IsWorking == false)
                {
                    worker = w;
                    return worker;
                }
            }
            return worker;
        }
        

        private void HiredWriter()
        {
            logForBakeryRelatedUpdates.Log(bakery.listOfBakers[bakery.listOfBakers.Count - 1].FirstName + " " + bakery.listOfBakers[bakery.listOfBakers.Count - 1].LastName + " hired!" + " (" + bakery.listOfBakers[bakery.listOfBakers.Count - 1].WorkTitle + ")");
        }

        public string[] WorkingBakers()
        {
            string[] arrayOfBakers = new string[bakery.listOfBakers.Count];
            for (int i = 0; i < bakery.listOfBakers.Count; i++)
            {
                arrayOfBakers[i] = i + 1 + ". " + bakery.listOfBakers[i].FirstName + " " + bakery.listOfBakers[i].LastName + " (" + bakery.listOfBakers[i].WorkTitle + ")";
            }
            return arrayOfBakers;
        }
    }
}
