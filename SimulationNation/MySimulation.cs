using BakeryLibrary;
using ConsoleSimulationEngine2000;
using SimulationNation.Commands;
using System;
using System.Collections.Generic;
namespace SimulationNation
{
    public class MySimulation : Simulation
    {
        public readonly Bakery bakery = new Bakery();
        private Payments payments = new Payments();
        public readonly Writer writer = new Writer();
        public bool generateCustomers = false;
        private ConsoleGUI gui;
        private TextInput input;
        public DateTime actualTime;
        private DateTime currentDay;
        private int simulationDay;




        private RollingDisplay newOrdersLog = new RollingDisplay(0, 0, 75, 12);
        private RollingDisplay completedOrdersLog = new RollingDisplay(74, 0, 76, 12);
        private BorderedDisplay pantryDisplay = new BorderedDisplay(0, 13, 42, 3) { };
        private BorderedDisplay commandDisplay = new BorderedDisplay(-30, 11, 30, 6) { };
        private BorderedDisplay moneyDisplay = new BorderedDisplay(20, 11, 22, 3) { };
        private BorderedDisplay clockDisplay = new BorderedDisplay(0, 11, 22, 3) { };
        private BorderedDisplay workingBakers = new BorderedDisplay(0, 15, 42, 10) { };
        public readonly RollingDisplay logForBakeryRelatedUpdates = new RollingDisplay(41, 15, 77, 10) { };



        public MySimulation(ConsoleGUI gui, TextInput input)
        {
            actualTime = DateTime.Now;
            currentDay = actualTime;
            simulationDay = 1;
            logForBakeryRelatedUpdates.Log("Welcome to this made up bakery!");
            logForBakeryRelatedUpdates.Log("Select which command to run by typing a number from the list of commands");
            commandDisplay.Lines = writer.CommandWriter();
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
            workingBakers.Lines = writer.WorkingBakers(bakery);
            moneyDisplay.Value = bakery.currentMoney + " Schmeckles";
            pantryDisplay.Value = ("Sugar: " + bakery.pantry["Sugar"] + "  Egg: " + bakery.pantry["Egg"] + "  Butter: " + bakery.pantry["Butter"]);


            if (generateCustomers)
            {
                actualTime = actualTime.AddMinutes(30);
                string newOrderString = bakery.GenerateNewOrder(actualTime);
                string orderCompleteString =bakery.CheckIfOrderIsComplete(actualTime, payments);
                string apprenticeUpgradeString = bakery.UpgradeApprentice(actualTime);
                if (newOrderString != "")
                {
                    newOrdersLog.Log(newOrderString);
                }
                if (orderCompleteString != "")
                {
                    completedOrdersLog.Log(orderCompleteString);
                }
                if (apprenticeUpgradeString != "")
                {
                    logForBakeryRelatedUpdates.Log(apprenticeUpgradeString);
                }
            }


            //making sure that this runs even if month or year changes
            if (actualTime.Day > currentDay.Day || actualTime.Month > currentDay.Month || actualTime.Year > currentDay.Year)
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
                ExecuteCommand(commandInput, this);
            }

        }

        public void ExecuteCommand(string commandToExecute, MySimulation simulation)
        {

            try
            {
                int commandIndex = int.Parse(commandToExecute) - 1;
                writer.ListOfCommands[commandIndex].Execute(simulation);
            }
            catch
            {
                logForBakeryRelatedUpdates.Log("Invalid command (" + commandToExecute + "), please try again");
            }

        }

    }
}
