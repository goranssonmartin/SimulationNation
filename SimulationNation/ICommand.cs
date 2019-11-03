using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationNation
{
    public interface ICommand
    {
        string CommandName { get; set; }
        void Execute(MySimulation simulation);
    }
}
