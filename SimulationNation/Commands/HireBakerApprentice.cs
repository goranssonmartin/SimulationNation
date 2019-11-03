using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationNation.Commands
{
    class HireBakerApprentice : ICommand
    {
        public string CommandName { get; set; }
        public HireBakerApprentice()
        {
            CommandName = "Hire Baker Apprentice";
        }
        public void Execute(MySimulation simulation)
        {
            simulation.bakery.HireApprentice(simulation.actualTime);
            simulation.logForBakeryRelatedUpdates.Log(simulation.writer.HiredWriter(simulation.bakery));
        }
    }
}
