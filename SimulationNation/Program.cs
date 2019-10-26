using ConsoleSimulationEngine2000;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bakery;

namespace SimulationNation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var input = new TextInput();
            var gui = new ConsoleGUI() { Input = input };
            var sim = new MySimulation(gui, input);
            await gui.Start(sim);

        }
    }

    public class MySimulation : Simulation
    {
        private ConsoleGUI gui;
        private TextInput input;

        public MySimulation(ConsoleGUI gui, TextInput input)
        {
            this.gui = gui;
            this.input = input;
        }

        public override List<BaseDisplay> Displays => throw new NotImplementedException();

        public override void PassTime(int deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
