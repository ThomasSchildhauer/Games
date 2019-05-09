using Autofac;
using Games.Plugin.Sudoku.Container;
using GamesUI;
using GamesUI.Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GamesUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUIContainer uIcontainer = new UIContainer();
            IContainer container = uIcontainer.Config();
            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IProgramm>();

                app.Run();
            }
        }
    }
}
