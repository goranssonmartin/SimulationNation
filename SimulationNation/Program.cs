using ConsoleSimulationEngine2000;
using System.Threading.Tasks;
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
}
