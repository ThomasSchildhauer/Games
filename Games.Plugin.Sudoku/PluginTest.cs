using Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku
{
    public class PluginTest : IGamesPlugin
    {
        public string Name { get; } = "Test Plugin";

        public void OnStartup()
        {
            Console.WriteLine("Hat geklappt");
            Console.ReadKey();
        }
    }
}
