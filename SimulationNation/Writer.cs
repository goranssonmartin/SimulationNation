using BakeryLibrary;
using SimulationNation.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimulationNation
{
    public class Writer
    {
        internal string[] CommandWriter()
        {

            List<ICommand> listOfCommands = new List<ICommand>() { new StartSimulation(), new HireBaker(),new HireBakerApprentice(), new StopSimulation() };
            string[] arrayOfCommands = new string[listOfCommands.Count];
            for (int i = 0; i < listOfCommands.Count; i++) {
                arrayOfCommands[i] = i + 1 + ". " + listOfCommands[i].CommandName;
            }
            return arrayOfCommands;
        }

        public string HiredWriter(Bakery bakery)
        {
            if (bakery.listOfBakers.Count < 9)
            {
                return bakery.listOfBakers.Last().Name + " hired!" + " (" + bakery.listOfBakers.Last().WorkTitle + ")";
            }
            else {
                return "you have reached the maximum number of bakers";
            }
        }
    }
}
