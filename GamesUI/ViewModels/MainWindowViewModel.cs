using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GamesUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GamesUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private static readonly log4net.ILog log = Logger.GetNewLogger();

        public ICommand Login
        {
            get => new RelayCommand(() => log.Debug("Login"));
        }

        public ICommand Refresh
        {
            get => new RelayCommand(() => log.Debug("Refresh"));
        }

        private IPluginViewModel _pluginViewModel;

        public IPluginViewModel PluginViewModel
        {
            get => _pluginViewModel;
            set
            {
                Set(nameof(PluginViewModel), ref _pluginViewModel);
            }
        }

        public MainWindowViewModel(IPluginViewModel pluginViewModel)
        {
            log.Debug("Start Games Programm");
            _pluginViewModel = pluginViewModel;
        }

        public MainWindowViewModel()
        {
            _pluginViewModel = new PluginViewModel();
        }
    }
}
