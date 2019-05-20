using GamesUI.PluginInterfaces;
using System;


namespace Games.Plugin.Sudoku
{
    public class StartSudokuPlugin : IPlugin
    {
        //private static readonly log4net.ILog log = LogHelper.GetNewLogger();
        //public string Name { get; } = "Sudoku";

        //private ISudokuPlugin _sudokuPlugin;

        //public StartSudokuPlugin(ISudokuPlugin sudokuPlugin)
        //{
        //    _sudokuPlugin = sudokuPlugin;
        //}

        //public void OnStartup()
        //{

        //    log.Debug("Start: Start Games Plugin Sudoku");

        //    Task.Run(() => _sudokuPlugin.RunAsync());

        //    //var container = Container.Container.Config();

        //    //using (ContainerScope.Scope = container.BeginLifetimeScope())
        //    //{
        //    //    log.Debug("Start: Resolve ISudokuPlugin");

        //    //    var app = ContainerScope.Scope.Resolve<ISudokuPlugin>();

        //    //    Task.Run(() => app.RunAsync());
        //    //}
        //}
        public string Name { get; } = "Sudoku Plugin";

        public string Text { get; private set; }

        public void OnStartup()
        {
            Text = "Juhuuuu";
        }
    }
}
