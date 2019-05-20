using GamesUI.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku
{
    public class PluginTest : IPlugin
    {
        public string Name => throw new NotImplementedException();

        public void OnStartup()
        {
            Console.WriteLine("Hat geklappt");
            Console.ReadKey();
        }
    }
}
