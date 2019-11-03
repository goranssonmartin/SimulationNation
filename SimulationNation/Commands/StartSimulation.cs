using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationNation.Commands
{
    class StartSimulation : ICommand
    {
        public string CommandName { get; set; }
        public StartSimulation()
        {
            CommandName = "Start";
        }
        public void Execute(MySimulation simulation)
        {
            simulation.generateCustomers = true;
            simulation.logForBakeryRelatedUpdates.Log("Simulation started");
        }
    }
}
