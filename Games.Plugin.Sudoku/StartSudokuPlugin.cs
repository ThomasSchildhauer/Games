using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Plugin.Sudoku.Container;
using Autofac;
using Base.LogHelper;
using Base.Interfaces;

namespace Games.Plugin.Sudoku
{
    public class StartSudokuPlugin : IGamesPlugin
    {
        private static readonly log4net.ILog log = LogHelper.GetNewLogger();

        public StartSudokuPlugin()
        {
            Name = "Sudoku";
        }

        public string Name
        {
            get;
            set;
        }

        public void OnStartup()
        {
            log.Debug("Start: Start Games Plugin Sudoku");

            var container = Container.Container.Config();

            using (ContainerScope.Scope = container.BeginLifetimeScope())
            {
                log.Debug("Start: Resolve ISudokuPlugin");

                var app = ContainerScope.Scope.Resolve<ISudokuPlugin>();

                Task.Run(() => app.RunAsync());
            }
        }
    }
}
