using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationNation.Commands
{
    class HireBaker : ICommand
    {
        public string CommandName { get; set; }
        public HireBaker()
        {
            CommandName = "Hire Baker";
        }

        public void Execute(MySimulation simulation)
        {
            simulation.bakery.HireBaker(simulation.actualTime);
            simulation.logForBakeryRelatedUpdates.Log(simulation.writer.HiredWriter(simulation.bakery));
        }
    }
}
