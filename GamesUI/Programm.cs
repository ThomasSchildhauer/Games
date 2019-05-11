using Autofac.Features.Metadata;
using Base.Interfaces;
using GamesUI.ViewModels;
using GamesUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI
{
    public class Programm : IProgramm
    {
        private IMainWindowViewModel _mainWindowViewModel;
        private MainWindowView _mainWindowView;
        IPluginViewModel _pluginViewModel;
        PluginView _pluginView;

        public Programm(
            IMainWindowViewModel mainWindowViewModel,
            MainWindowView mainWindowView,
            IPluginViewModel pluginViewModel,
            PluginView pluginView)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _mainWindowView = mainWindowView;
            _pluginViewModel = pluginViewModel;
            _pluginView = pluginView;
        }

        public void Run()
        {
            _pluginView.DataContext = _pluginViewModel;
            _mainWindowView.DataContext = _mainWindowViewModel;
            _mainWindowView.Show();
        }
    }
}
