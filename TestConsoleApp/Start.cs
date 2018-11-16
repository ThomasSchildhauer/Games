using Autofac;
using Games.Plugin.Sudoku;
using Games.Plugin.Sudoku.ContainerConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Start
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Config();

            using (var scope = container.BeginLifetimeScope())
            {
                var _programm = scope.Resolve<ISudokuPlugin>();

                _programm.Run();
            }
        }
    }
}
