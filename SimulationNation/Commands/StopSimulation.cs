using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationNation.Commands
{
    class StopSimulation : ICommand
    {
        public string CommandName { get; set; }
        public StopSimulation() {
            CommandName = "Stop";
        }
        public void Execute(MySimulation simulation)
        {
            if (simulation.generateCustomers == true)
            {
                simulation.generateCustomers = false;
                simulation.logForBakeryRelatedUpdates.Log("Simulation stopped");
            }
        }
    }
}
