using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GamesBase.Messages;
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

        private UIViewModelToken _token;

        public ICommand LoginCommand
        {
            get => new RelayCommand(() =>
            {
                //_loginViewModel.Visible = true;
                MessengerInstance.Send(new ControleVisible(nameof(LoginViewModel)), _token);
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
                MessengerInstance.Send(new ControleVisible(nameof(PluginViewModel)), _token);
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
            UIViewModelToken token,
            IPluginViewModel pluginViewModel,
            ILoginViewModel loginViewModel)
        {
            log.Debug("Start Games Programm");
            _pluginViewModel = pluginViewModel;
            _loginViewModel = loginViewModel;
            _token = token;

        }
    }
}
