using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Plugin.Sudoku.ContainerConfig;
using Autofac;

namespace Games.Plugin.Sudoku
{
    public static class StartSudokuPlugin
    {
        public static void Start()
        {
            var container = ContainerConfig.ContainerConfig.Config();

            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISudokuPlugin>();

                Task.Run(()=>app.Run());
            }
        }
    }
}
