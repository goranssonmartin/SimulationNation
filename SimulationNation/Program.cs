using ConsoleSimulationEngine2000;
using System.Threading.Tasks;
using Bakery;
namespace SimulationNation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Bakery.Bakery bakery = new Bakery.Bakery();
            var input = new TextInput();
            var gui = new ConsoleGUI() { Input = input };
            var sim = new MySimulation(gui, input);
            await gui.Start(sim);

        }
    }
}
