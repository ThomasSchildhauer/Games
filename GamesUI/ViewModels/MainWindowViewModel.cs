using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GamesUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GamesUI.Messages;

namespace GamesUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private static readonly log4net.ILog log = Logger.GetNewLogger();

        public ICommand LoginCommand
        {
            get => new RelayCommand(() =>
            {
                _loginViewModel.Visible = true;
                MessengerInstance.Send(new ControleVisible(nameof(LoginViewModel)));
            });
        }

        public ICommand RefreshCommand
        {
            get => new RelayCommand(() => log.Debug("Refresh"));
        }

        public ICommand PluginsCommand
        {
            get => new RelayCommand(() => 
            {
                
                _pluginViewModel.Visible = true;
                MessengerInstance.Send(new ControleVisible(nameof(PluginViewModel)));
            });
        }

        private IPluginViewModel _pluginViewModel;

        public IPluginViewModel PluginViewModel
        {
            get => _pluginViewModel;
            set
            {
                Set(nameof(PluginViewModel), ref _pluginViewModel, value);
            }
        }

        private ILoginViewModel _loginViewModel;

        public ILoginViewModel LoginViewModel
        {
            get => _loginViewModel;
            private set
            {
                Set(nameof(LoginViewModel), ref _loginViewModel, value);
            }
        }

        public MainWindowViewModel(
            IPluginViewModel pluginViewModel,
            ILoginViewModel loginViewModel)
        {
            log.Debug("Start Games Programm");
            _pluginViewModel = pluginViewModel;
            _loginViewModel = loginViewModel;


        }
    }
}
