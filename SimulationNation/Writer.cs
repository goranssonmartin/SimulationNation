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
        public List<ICommand> ListOfCommands { get; set; }
        public Writer() { 
        ListOfCommands = new List<ICommand>() { new StartSimulation(), new HireBaker(), new HireBakerApprentice(), new StopSimulation() };
        }

        internal string[] CommandWriter()
        {            
            string[] arrayOfCommands = new string[ListOfCommands.Count];
            for (int i = 0; i < ListOfCommands.Count; i++) {
                arrayOfCommands[i] = i + 1 + ". " + ListOfCommands[i].CommandName;
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
                return "You have reached the maximum number of bakers";
            }
        }

        public string[] WorkingBakers(Bakery bakery)
        {
            string[] arrayOfBakers = new string[bakery.listOfBakers.Count];
            for (int i = 0; i < bakery.listOfBakers.Count; i++)
            {
                arrayOfBakers[i] = i + 1 + ". " + bakery.listOfBakers[i].Name + " (" + bakery.listOfBakers[i].WorkTitle + ")";
            }
            return arrayOfBakers;
        }
    }
}
