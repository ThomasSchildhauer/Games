using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Plugin.Sudoku.ContainerConfig;
using Autofac;
using Base.LogHelper;

namespace Games.Plugin.Sudoku
{
    public static class StartSudokuPlugin
    {
        private static readonly log4net.ILog log = LogHelper.GetNewLogger();

        public static void Start()
        {
            log.Debug("Start: Start Games Plugin Sudoku");

            var container = ContainerConfig.ContainerConfig.Config();

            using(var scope = container.BeginLifetimeScope())
            {
                log.Debug("Start: Resolve ISudokuPlugin");

                var app = scope.Resolve<ISudokuPlugin>();

                Task.Run(()=>app.RunAsync());
            }
        }
    }
}
