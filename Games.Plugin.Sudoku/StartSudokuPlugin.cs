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
        public string Name { get; } = "Sudoku";

        private ISudokuPlugin _sudokuPlugin;

        public StartSudokuPlugin(ISudokuPlugin sudokuPlugin)
        {
            _sudokuPlugin = sudokuPlugin;
        }

        public void OnStartup()
        {

            log.Debug("Start: Start Games Plugin Sudoku");

            Task.Run(() => _sudokuPlugin.RunAsync());

            //var container = Container.Container.Config();

            //using (ContainerScope.Scope = container.BeginLifetimeScope())
            //{
            //    log.Debug("Start: Resolve ISudokuPlugin");

            //    var app = ContainerScope.Scope.Resolve<ISudokuPlugin>();

            //    Task.Run(() => app.RunAsync());
            //}
        }
    }
}
